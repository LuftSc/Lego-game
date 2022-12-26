using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TerrainUtils;

public class PutDetail2dot0 : MonoBehaviour
{
   //СТАВИМ В ИНСПЕКТОРЕ
   public GameObject detailPrefab;
   //САМИ СЧИТАЕМ
   private static TextMeshProUGUI _count;
   private static bool _isInit;
   private static Dictionary<string, List<Vector3>> _puttedDetails;

   private void Awake()
   {
      _puttedDetails = new Dictionary<string, List<Vector3>>();
   }

   public void OnClick()
   {
      ClickToMoveButton.cubeMove = false;
      ClickControl.cubeChoosen = true;
      ClickControl.cubePrefab = detailPrefab;
      _count = gameObject.transform.parent.Find("count").gameObject.GetComponent<TextMeshProUGUI>();
      ClickControl.count = _count;
      _isInit = true;
   }
   private void Update()
   {
      if (_isInit && _count.text == "x0" && _count.IsActive())
      {
         _count.transform.parent.gameObject.SetActive(false);
         var isEmptyPanel = CheckButtonsOnThemActive();

         if (isEmptyPanel && CheckTruePlaceOfDetail())
         {
            CreateButtons.start = true;
         }
      }
   }
   public bool CheckButtonsOnThemActive()
   {
      var activeObjects = GameObject.FindGameObjectsWithTag("Detail");
      foreach (var obj in activeObjects)
         if (obj.activeSelf) return false;

      return true;
   }

   public static bool CheckTruePlaceOfDetail()
   {
      var details = GameObject.FindGameObjectsWithTag("MovementObj");
      var puttedDetails = new Dictionary<string, List<Vector3>>();
      var allRight = false;
      // 2x1_fat_green(Clone)
      foreach (var detail in details)
      {
         var split_values = detail.name.Split("_");
         var size = split_values[0];
         Debug.Log(detail.name);
         var color = split_values[2].Split("(")[0];
         var position = detail.transform.position;
         var final_name = $"{color}_{size}";

         if (puttedDetails.ContainsKey(final_name))
         {
            var currentList = puttedDetails[final_name];
            currentList.Add(position);
            puttedDetails[final_name] = currentList;
         }
         else puttedDetails[final_name] = new List<Vector3> { position };
      }
      
      if (_puttedDetails.Count == 0) _puttedDetails = new Dictionary<string, List<Vector3>>(puttedDetails);
      else
      {
         foreach (var key in puttedDetails.Keys)
         {
            if (_puttedDetails.ContainsKey(key))
            {
               //var newList = new List<Vector3>(puttedDetails[key]);
               //_puttedDetails[key].AddRange(newList);
               //_puttedDetails[key] = new List<Vector3>(_puttedDetails[key]);

               foreach (var pos in puttedDetails[key])
               {
                  _puttedDetails[key].Add(pos);
               }
            }
            else _puttedDetails.Add(key, puttedDetails[key]);
         }
      }
      
      Debug.Log(CreateButtons.NumberOfInstruction);
      switch (CreateButtons.NumberOfInstruction)
      {
         case 1:
            allRight = CheckCountPuttedDetails(new Dictionary<string, Tuple<int, int, int>> ()
               {
                  ["orange_2x1"] = Tuple.Create(1, 2, 2) ,
                  ["green_2x1"] = Tuple.Create(2, 2, 1)
               }
               , extraCheck1);
            break;
         case 2:
            allRight = CheckCountPuttedDetails(new Dictionary<string, Tuple<int, int, int>>()
               {
                  ["dorange_2x1"] = Tuple.Create(1, 2, 2),
                  ["orange_2x2"] = Tuple.Create(1, 2, 2),
                  ["green_2x1"] = Tuple.Create(2, 3, 1)
               }
               , extraCheck1);
            break;
      }
      Debug.Log(allRight);
      
      if (allRight)
      {
         foreach (var detail in details)
         {
            detail.tag = "Untagged";
         }
      }

      
      return allRight;

   }

   private static Func<Dictionary<float, int>, int, int, bool> extraCheck1 = (uniqD, minDist, maxDist) =>
   {
      var last = uniqD.Keys.Last();
      var result = false;
      foreach (var key in uniqD.Keys)
      {
         if (key == last) break;
         var result_dist = Mathf.Abs(Mathf.Abs(key) - Mathf.Abs(last));
         if ( result_dist < maxDist && result_dist > minDist) result = true;
      }
      return result;
   };

   private static List<string> namePutted_D = new List<string>();

   private static Dictionary<float, int> uniqueDictX_A = new Dictionary<float, int>();
   private static Dictionary<float, int> uniqueDictY_A = new Dictionary<float, int>();
   private static Dictionary<float, int> uniqueDictZ_A = new Dictionary<float, int>();
   public static bool CheckCountPuttedDetails(Dictionary<string, Tuple<int, int, int>> assertDetails,
      Func<Dictionary<float, int>, int, int, bool> extraCheck)
   {
      var checkCount = true;
      foreach (var key in assertDetails.Keys)
      {
         var uniqueDictX = new Dictionary<float, int>();
         var uniqueDictY = new Dictionary<float, int>();
         var uniqueDictZ = new Dictionary<float, int>();
         //Debug.Log($"Count: {_puttedDetails.Count}");
         if (namePutted_D.IndexOf(key) > -1)
         {
            //Debug.Log($" before {uniqueDictX.Count} {uniqueDictY.Count} {uniqueDictZ.Count}");
            //uniqueDictX = uniqueDictX_A;
            //uniqueDictY = uniqueDictY_A;
            //uniqueDictZ = uniqueDictZ_A;
            //Debug.Log($" before {uniqueDictX.Count} {uniqueDictY.Count} {uniqueDictZ.Count}");
            
         } else namePutted_D.Add(key);
         

         Action<float, char> tryPlustoDictionary = (coord, letter) =>
         {
            var rnd_coord = (float)Math.Round(coord);
            switch (letter)
            {
               case 'x':
                  if (uniqueDictX.ContainsKey(rnd_coord)) uniqueDictX[rnd_coord] += 1;
                  else uniqueDictX.Add(rnd_coord, 1);
                  break;
               case 'y':
                  if (uniqueDictY.ContainsKey(rnd_coord)) uniqueDictY[rnd_coord] += 1;
                  else uniqueDictY[rnd_coord] = 1;
                  break;
               case 'z':
                  if (uniqueDictZ.ContainsKey(rnd_coord)) uniqueDictZ[rnd_coord] += 1;
                  else uniqueDictZ[rnd_coord] = 1;
                  break;
            }
         };
         foreach (var pos in _puttedDetails[key])
         {
            //Debug.Log($"{key} {_puttedDetails[key].Count}");
            tryPlustoDictionary(pos.x, 'x');
            tryPlustoDictionary(pos.y, 'y');
            tryPlustoDictionary(pos.z, 'z');
         }
         //Debug.Log($"{assertDetails[key].Item1} {assertDetails[key].Item2} {assertDetails[key].Item3}");
         //Debug.Log($"{uniqueDictX.Count} {uniqueDictY.Count} {uniqueDictZ.Count}");
         checkCount = assertDetails[key].Item1 == uniqueDictX.Count
                      && assertDetails[key].Item2 == uniqueDictY.Count
                      && assertDetails[key].Item3 == uniqueDictZ.Count;
         switch (CreateButtons.NumberOfInstruction)
         {
            case 1:
               switch (key)
               {
                  case "orange_2x1": checkCount = checkCount && extraCheck(uniqueDictZ, 4, 7);
                     break;
                  case "green_2x1": checkCount = checkCount && extraCheck(uniqueDictX, 2, 5) && extraCheck(uniqueDictY, 3, 5);
                     break;
               }
               break;
            case 2:
               switch (key)
               {
                  case "dorange_2x1":
                     checkCount = checkCount && extraCheck(uniqueDictY, 3, 5) && extraCheck(uniqueDictZ, 4, 7);
                     break;
                  case "orange_2x2":
                     checkCount = checkCount && extraCheck(uniqueDictY, 3, 5) && extraCheck(uniqueDictZ, 3, 5);
                     break;
               }
               break;
            
         }
         /*switch (key)
         {
            case "orange_2x1": checkCount = checkCount && extraCheck(uniqueDictZ, 4, 7);
               break;
            case "green_2x1": checkCount = checkCount && extraCheck(uniqueDictX, 2, 5) && extraCheck(uniqueDictY, 3, 5);
               break;
         } */
         //if (checkCount) checkCount = checkCount && extraCheck(uniqueDictZ, 4, 7);
      }

      if (!checkCount) Debug.Log("All very bad....");
      return checkCount;
   }
}