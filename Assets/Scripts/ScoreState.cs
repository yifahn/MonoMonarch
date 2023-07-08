using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public static class ScoreState
{
    public static double score, scoreMultiplier, scoreGainRate;
    public static double maxNumHouses, maxNumLibraries, maxNumFactories, maxNumWonders;
    public static double numHouses, numLibraries, numFactories, numCityCentres, numWonders, numBlockades, numRoads, numForests, numMTowers, numAATowers, numFarms;
    public static double roadPrice, blockadePrice, towerMPrice, towerAAPrice, housePrice, libraryPrice, factoryPrice, wonderPrice;
    public static double houseGainRate, libraryMultiplier, factoryGainRate, factoryMultiplier, wonderMultiplier;


    public static void RenewGame()
    {
        Score = 0;
        ScoreMultiplier = 0;
        ScoreGainRate = 0;

        MaxNumFactories = 0;
        MaxNumHouses = 0;
        MaxNumLibraries = 0;
        MaxNumWonders = 0;
    
        NumHouses = 0;
        NumForests = 0;
        NumBlockades = 0;
        NumAATowers = 0;
        NumCityCentres = 0;
        NumFarms = 0;
        NumLibraries = 0;
        NumMTowers = 0;
        NumRoads = 0;
        NumWonders = 0; 
        NumFactories = 0;

        RoadPrice = 0;
        LibraryPrice = 0;
        HousePrice = 0;
        FactoryPrice = 0;
        BlockadePrice = 0;
        TowerAAPrice = 0;
        TowerMPrice = 0;
        WonderPrice = 0;

        HouseGainRate = 0;
        LibraryMultiplier = 0;
        FactoryGainRate = 0;
        FactoryMultiplier = 0;
        WonderMultiplier = 0;
       
        SaveAndLoad.IsReadyLoadFunction = false;
        SaveAndLoad.IsReadyPlay = false;//s
        SaveAndLoad.SaveFileSelected = null;
        SaveAndLoad.SaveFileDir = null;//s
        SaveAndLoad.IsNew = false;
        SaveAndLoad.IsLoad = false;
        SaveAndLoad.IsInGame = false;
        

    }

    public static double NumBlockades
    {
        get { return numBlockades; }
        set { numBlockades = value; }
    }
    public static double NumRoads//////////////sssssssssssssssssss
    {//ss
        get { return numRoads; }
        set { numRoads = value; }
    }
    public static double NumFarms
    {
        get { return numFarms; }
        set { numFarms = value; }
    }
    public static double NumForests
    {
        get { return numForests; }
        set { numForests = value; }
    }
    public static double NumMTowers
    {
        get { return numMTowers; }
        set { numMTowers = value; }
    }
    public static double NumAATowers
    {
        get { return numAATowers; }
        set { numAATowers = value; }
    }

    public static double RoadPrice
    {
        get { return roadPrice; }
        set { roadPrice = value; }
    }
    public static double BlockadePrice
    {
        get { return blockadePrice; }
        set { blockadePrice = value; }
    }
    public static double TowerAAPrice
    {
        get { return towerAAPrice; }
        set { towerAAPrice = value; }
    }
    public static double TowerMPrice
    {
        get { return towerMPrice; }
        set { towerMPrice = value; }
    }
    public static double HouseGainRate
    {
        get { return houseGainRate; }
        set { houseGainRate = value; }
    }
    public static double LibraryMultiplier
    {
        get { return libraryMultiplier; }
        set { libraryMultiplier = value; }
    }
    public static double FactoryGainRate
    {
        get { return factoryGainRate; }
        set { factoryGainRate = value; }
    }
    public static double FactoryMultiplier
    {
        get { return factoryMultiplier; }
        set { factoryMultiplier = value; }
    }
    public static double WonderMultiplier
    {
        get { return wonderMultiplier; }
        set { wonderMultiplier = value; }
    }

    public static double HousePrice
    {
        get { return housePrice; }
        set { housePrice = value; }

    }
    public static double LibraryPrice
    {
        get { return libraryPrice; }
        set { libraryPrice = value; }

    }
    public static double FactoryPrice
    {
        get { return factoryPrice; }
        set { factoryPrice = value; }

    }
    public static double WonderPrice
    {
        get { return wonderPrice; }
        set { wonderPrice = value; }

    }
    public static double MaxNumHouses
    {
        get { return maxNumHouses; }
        set { maxNumHouses = value; }
    }
    public static double MaxNumLibraries
    {
        get { return maxNumLibraries; }
        set { maxNumLibraries = value; }
    }
    public static double MaxNumFactories
    {
        get { return maxNumFactories; }
        set { maxNumFactories = value; }
    }
    public static double MaxNumWonders
    {
        get { return maxNumWonders; }
        set { maxNumWonders = value; }
    }
    public static double NumHouses
    {
        get { return numHouses; }
        set { numHouses = value; }
    }
    public static double NumLibraries
    {
        get { return numLibraries; }
        set { numLibraries = value; }
    }
    public static double NumFactories
    {
        get { return numFactories; }
        set { numFactories = value; }
    }
    public static double NumCityCentres
    {
        get { return numCityCentres; }
        set { numCityCentres = value; }
    }
    public static double NumWonders
    {
        get { return numWonders; }
        set { numWonders = value; }
    }

    public static double Score
    {
        get { return score; }
        set { score = value; }
    }
    public static double ScoreGainRate
    {
        get { return scoreGainRate; }
        set { scoreGainRate = value; }
    }
    public static double ScoreMultiplier
    {
        get { return scoreMultiplier; }
        set { scoreMultiplier = value; }
    }
    //public double numHouse, numLibrary,numFactory,numCityCentre,numWonder;
    //double numHouse, double numLibrary, double numFactory,double numCityCentre,double numWonder
    /*  public static ScoreState(double score, double scoreGainRate, double scoreMultiplier,bool isLoad)
      {
          this.Score = score;
          this.ScoreGainRate = scoreGainRate;
          this.ScoreMultiplier = scoreMultiplier;
          this.IsLoad = isLoad;
      }
      public static ScoreState()
      {
          //overload for no props
      } */
    /*  public void AddScoreMultiplier(double scoreMultiplierToIncrementBy)
      {
          ScoreMultiplier += scoreMultiplierToIncrementBy;
      }
      public void SubtractScoreMultiplier(double scoreMultiplierToDecrementBy)
      {
          ScoreMultiplier -= scoreMultiplierToDecrementBy;
      }

      public void AddScoreGainRate(double ScoreGainRateToIncrementBy)
      {
          ScoreGainRate += ScoreGainRateToIncrementBy;
      }
      public void SubtractScoreGainRate(double ScoreGainRateToDecrementBy)
      {
          ScoreGainRate -= ScoreGainRateToDecrementBy;
      }

      public void AddScore(double scoreToIncrementBy)
      {
          Score += scoreToIncrementBy;
      }
      public void SubtractScore(double scoreToDecrementBy)
      {
          Score -= scoreToDecrementBy;
      }

      public void IsLoadBool (bool isLoadInput)
      {
          if (isLoadInput)
          {
              IsLoad = false;
          }
          else 
          {
              IsLoad = true;
          }
      }
    */
    /* public double NumWonder
     {
         get { return numWonder; }
         set { numWonder = value; }
     }
     public double NumLibrary
     {
         get { return numLibrary; }
         set { numLibrary = value; }
     }
     public double NumFactory
     {
         get { return numFactory; }
         set { numFactory = value; }
     }
     public double NumCityCentre
     {
         get { return numCityCentre; }
         set { numCityCentre = value; }
     }
    */

    /* public double NumHouse
 {
     get {return numHouse; }
     set {numHouse = value; }
 }*/
}
