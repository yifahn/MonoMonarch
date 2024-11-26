using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System;
using System.Linq;

[System.Serializable]
public static class SaveAndLoad
{
    public static string saveFileDir;
    public static string saveFileSelected;
    public static string saveFileName;
    public static bool isReady, isReadyPlay;

    public static bool hasReturnedFromOtherScene;
    public static double scoreTempFromOtherScene1, scoreTempFromOtherScene2;

    public static bool isLoad, isNew, isInGame;
    public static double ScoreTempFromOtherScene2
    {
        get { return scoreTempFromOtherScene2; }
        set { scoreTempFromOtherScene2 = value; }
    }
    public static double ScoreTempFromOtherScene1
    {
        get { return scoreTempFromOtherScene1; }
        set { scoreTempFromOtherScene1 = value; }
    }
    public static bool HasReturnedFromOtherScene
    {
        get { return hasReturnedFromOtherScene; }
        set { hasReturnedFromOtherScene = value; }
    }
    public static bool IsNew
    {
        get { return isNew; }
        set { isNew = value; }
    }
    public static bool IsInGame
    {
        get { return isInGame; }
        set { isInGame = value; }
    }

    public static bool IsLoad
    {
        get { return isLoad; }
        set { isLoad = value; }
    }

    public static string SaveFileName
    {
        get { return saveFileName; }
        set { saveFileName = value; }
    }


    public static bool IsReadyLoadFunction
    {
        get { return isReady; }
        set { isReady = value; }
    }
    public static bool IsReadyPlay
    {
        get { return isReadyPlay; }
        set { isReadyPlay = value; }
    }
    public static string SaveFileDir
    {
        get { return saveFileDir; }
        set { saveFileDir = value; }
    }
    public static string SaveFileSelected
    {
        get { return saveFileSelected; }
        set { saveFileSelected = value; }
    }
    /// <summary>
    /// LOADING METHOD
    /// </summary>
    public static void LoadState()
    {
        Debug.Log(SaveFileSelected);
        using (StreamReader sr = new StreamReader(SaveFileSelected.Trim('\r', '\n')))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".1")
            {
                sb.AppendLine(line);
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            string setScore1 = splitInput[0];//
            string setScore2 = splitInput[1];
            string setScore3 = splitInput[2];
            string setScore4 = splitInput[3];
            ScoreState.Score = double.Parse(setScore1);
            ScoreState.ScoreGainRate = double.Parse(setScore2);
            ScoreState.ScoreMultiplier = double.Parse(setScore3);
            PlayerCharacterStaticClass.PlayerPP = int.Parse(setScore4);
            sr.Close();
        }
        using (StreamReader sr = new StreamReader(SaveFileSelected.Trim('\r', '\n')))
        {
            int tempInt = 0;
            var sb = new System.Text.StringBuilder();
            string line;
            string input;
            while ((line = sr.ReadLine()) != ".2")
            {
                if (line.Equals(".1"))
                {
                    sb.Clear();
                    tempInt = 0;
                }
                if (!line.Equals(".1"))
                {
                    tempInt++;
                    sb.AppendLine(line);
                }
            }
            string[] splitInput = new string[tempInt];
            input = sb.ToString();
            splitInput = input.Split('~');
            for (int i = 0; i < splitInput.Length; i++)
            {
                string cellName = splitInput[i];
                CellState.mapListL1.Add(cellName.Trim());
            }
            Debug.Log("removing: " + CellState.MapListL1[1980]);
            CellState.MapListL1.RemoveAt(1980);
            sr.Close();
        }
        using (StreamReader sr = new(SaveFileSelected.Trim('\r', '\n')))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".3")
            {
                if (line.Equals(".2"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".2"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');

            string setScore1 = splitInput[0];
            string setScore2 = splitInput[1];
            string setScore3 = splitInput[2];
            string setScore4 = splitInput[3];
            string setScore5 = splitInput[4];
            string setScore6 = splitInput[5];
            string setScore7 = splitInput[6];
            string setScore8 = splitInput[7];
            string setScore9 = splitInput[8];
            string setScore10 = splitInput[9];
            string setScore11 = splitInput[10];
            string setScore12 = splitInput[11];
            string setScore13 = splitInput[12];
            string setScore14 = splitInput[13];

            ScoreState.MaxNumHouses = double.Parse(setScore1);
            ScoreState.MaxNumLibraries = double.Parse(setScore2);
            ScoreState.MaxNumFactories = double.Parse(setScore3);
            ScoreState.MaxNumWonders = double.Parse(setScore4);
            ScoreState.NumBlockades = double.Parse(setScore5);
            ScoreState.NumForests = double.Parse(setScore6);
            ScoreState.NumAATowers = double.Parse(setScore7);
            ScoreState.NumMTowers = double.Parse(setScore8);
            ScoreState.NumRoads = double.Parse(setScore9);
            ScoreState.NumHouses = double.Parse(setScore10);
            ScoreState.NumLibraries = double.Parse(setScore11);
            ScoreState.NumFactories = double.Parse(setScore12);
            ScoreState.NumCityCentres = double.Parse(setScore13);
            ScoreState.NumWonders = double.Parse(setScore14);
            sr.Close();
        }
        using (StreamReader sr = new(SaveFileSelected.Trim('\r', '\n')))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".4")
            {
                if (line.Equals(".3"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".3"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            string setVar1 = splitInput[0];
            string setVar2 = splitInput[1];
            string setVar3 = splitInput[2];
            string setVar4 = splitInput[3];
            string setVar5 = splitInput[4];
            string setVar6 = splitInput[5];
            string setVar7 = splitInput[6];
            string setVar8 = splitInput[7];
            string setVar9 = splitInput[8];
            string setVar10 = splitInput[9];
            string setVar11 = splitInput[10];
            string setVar12 = splitInput[11];
            string setVar13 = splitInput[12];
            ScoreState.BlockadePrice = double.Parse(setVar1);
            ScoreState.RoadPrice = double.Parse(setVar2);
            ScoreState.TowerAAPrice = double.Parse(setVar3);
            ScoreState.TowerMPrice = double.Parse(setVar4);
            ScoreState.HousePrice = double.Parse(setVar5);
            ScoreState.LibraryPrice = double.Parse(setVar6);
            ScoreState.FactoryPrice = double.Parse(setVar7);
            ScoreState.WonderPrice = double.Parse(setVar8);
            ScoreState.HouseGainRate = double.Parse(setVar9);
            ScoreState.LibraryMultiplier = double.Parse(setVar10);
            ScoreState.FactoryGainRate = double.Parse(setVar11);
            ScoreState.FactoryMultiplier = double.Parse(setVar12);
            ScoreState.WonderMultiplier = double.Parse(setVar13);
            sr.Close();
        }
        using (StreamReader sr = new(SaveFileSelected.Trim('\r', '\n')))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".5")
            {
                if (line.Equals(".4"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".4"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            string setVar1 = splitInput[0];
            string setVar2 = splitInput[1];
            string setVar3 = splitInput[2];
            string setVar4 = splitInput[3];
            string cleanedTempString3 = setVar1.Replace("\n", "").Replace("\r", "");
            if (cleanedTempString3 == "True")
            {
                CellState.PlayerSpawnBool = true;
            }
            else
            {
                CellState.PlayerSpawnBool = false;
            }
            string cleanedTempString4 = setVar2.Replace("\n", "").Replace("\r", "");
            if (cleanedTempString4 == "True")
            {
                CellState.OpponentSpawnBool = true;
            }
            else
            {
                CellState.OpponentSpawnBool = false;
            }
            string cleanedTempString1 = setVar3.Replace("\n", "").Replace("\r", "");
            CellState.PlayerSpawn = cleanedTempString1;
            string cleanedTempString2 = setVar4.Replace("\n", "").Replace("\r", "");
            CellState.OpponentSpawn = cleanedTempString2;

            sr.Close();
        }
        using (StreamReader sr = new(SaveFileSelected.Trim('\r', '\n')))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".6")
            {
                if (line.Equals(".5"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".5"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');
            Debug.Log("MADE IT HERE");
            for (int i = 0; i < splitInput.Length - 1; i++)
            {
                string input2 = splitInput[i];
                CellState.MapListL2.Add(input2);
            }
            Debug.Log("MADE IT HERE");
            Debug.Log(CellState.MapListL2.Count);
            // Debug.Log(CellState.MapListL2[1]);
            sr.Close();
        }

        using (StreamReader sr = new(SaveFileSelected.Trim('\r', '\n')))
        {
            var sb = new System.Text.StringBuilder();
            string line;
            string[] splitInput;
            string input;
            while ((line = sr.ReadLine()) != ".7")
            {
                if (line.Equals(".6"))
                {
                    sb.Clear();
                }
                if (!line.Equals(".6"))
                {
                    sb.AppendLine(line);
                }
            }
            input = sb.ToString();
            splitInput = input.Split('~');

            PlayerCharacterStaticClass.PlayerHealth = int.Parse(splitInput[0]);
            PlayerCharacterStaticClass.PlayerHealthMax = int.Parse(splitInput[1]);
            PlayerCharacterStaticClass.PlayerStamina = int.Parse(splitInput[2]);
            PlayerCharacterStaticClass.PlayerStaminaMax = int.Parse(splitInput[3]);
            PlayerCharacterStaticClass.PlayerStrength = int.Parse(splitInput[4]);
            PlayerCharacterStaticClass.PlayerDefence = int.Parse(splitInput[5]);
            PlayerCharacterStaticClass.PlayerLuck = int.Parse(splitInput[6]);
            PlayerCharacterStaticClass.PlayerName = splitInput[7];
            PlayerCharacterStaticClass.PlayerClass = splitInput[8];
            PlayerCharacterStaticClass.PlayerLevel = int.Parse(splitInput[9]);
            PlayerCharacterStaticClass.PlayerXP = int.Parse(splitInput[10]);
            Debug.Log("FINISHED LOAD");
            sr.Close();
        }
        IsReadyLoadFunction = true;//REMOVE?
    }
    /// <summary>
    /// SAVING METHOD
    /// 
    ///BELOW IS INFORMATION ABOUT WRITELINE AND TOSTRING 
    /// https://stackoverflow.com/questions/54569293/net-console-writeline-method-tostring-behavior
    /// 
    /// IS THERE A BETTER WAY TO HANDLE LINE FEEDS AND CARRIAGE RETURNS BEFORE AND AFTER DATA INSTEAD OF ADDING TRIM FUNCTION TO EVERY LINE OF CODE?
    /// </summary>
    public static void SaveState()
    {
        int index = 0;
        if (!IsLoad) { AssignSaveFileDirAndFileNameOnNew(); }
        Debug.Log("Save file selected: " + SaveFileSelected.Trim('\r', '\n'));
        Debug.Log(saveFileSelected);
        using (FileStream fs = new FileStream(SaveFileSelected.TrimEnd('\r', '\n'), FileMode.OpenOrCreate))
        {
            using (StreamWriter sw = new(fs))//s
            {
                sw.WriteLine(ScoreState.Score.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.ScoreGainRate.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.ScoreMultiplier.ToString().Trim('\r', '\n') + "~");//s
                sw.WriteLine(PlayerCharacterStaticClass.PlayerPP + "~");
                sw.WriteLine(".1");
                foreach (string cellName in CellState.MapListL1)
                {
                    sw.WriteLine(CellState.MapListL1[index].ToString().Trim('\r', '\n') + "~");
                    index++;
                }
                index = 0;
                sw.WriteLine(".2");
                sw.WriteLine(ScoreState.MaxNumHouses.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.MaxNumLibraries.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.MaxNumFactories.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.MaxNumWonders.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumBlockades.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumForests.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumAATowers.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumMTowers.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumRoads.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumHouses.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumLibraries.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumFactories.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumCityCentres.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.NumWonders.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(".3");
                sw.WriteLine(ScoreState.BlockadePrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.RoadPrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.TowerAAPrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.TowerMPrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.HousePrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.LibraryPrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.FactoryPrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.WonderPrice.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.HouseGainRate.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.LibraryMultiplier.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.FactoryGainRate.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.FactoryMultiplier.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(ScoreState.WonderMultiplier.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(".4");
                sw.WriteLine(CellState.PlayerSpawnBool.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(CellState.OpponentSpawnBool.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(CellState.PlayerSpawn + "~");
                sw.WriteLine(CellState.OpponentSpawn + "~");
                sw.WriteLine(".5");
                for (int j = 1; j <= 33; j++)
                {
                    for (int j2 = 1; j2 <= 60; j2++)
                    {
                        sw.WriteLine(CellState.MapListL2[index].ToString().Trim('\r', '\n') + "~");
                        index++;//ss

                    }
                }
                index = 0;
                sw.WriteLine(".6");

                sw.WriteLine(PlayerCharacterStaticClass.PlayerHealth.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerHealthMax.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerStamina.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerStaminaMax.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerStrength.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerDefence.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.playerLuck.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerName.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerClass.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerLevel.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(PlayerCharacterStaticClass.PlayerXP.ToString().Trim('\r', '\n') + "~");
                sw.WriteLine(".7");

                sw.Close();
            }
            fs.Close();
        }
        IsLoad = true;
    }
    public static void SaveScoreOnReturnToCityScene(double score)//s
    {
        ScoreTempFromOtherScene1 = score;
    }
    public static double UpdateScoreOnReturnToCityScene(double score)
    {
        ScoreTempFromOtherScene1 -= score;
        return ScoreTempFromOtherScene1;
    }
    public static void TestStringOutput()
    {
        string tempstring = @"c:\testsaves\saveTestFile1";
        using (FileStream fs = new FileStream(tempstring.TrimEnd('\r', '\n'), FileMode.OpenOrCreate))
        {
            using (StreamWriter sw = new(fs))//s
            {
                sw.WriteLine(saveFileSelected.Trim('\r', '\n'));
                sw.Close();
            }
            fs.Close();
        }
    }
    /// <summary>//ss
    /// ASSIGN FILE DIR AND FILE NAME & FILE SELECTED VARS IF LOAD GAME
    /// </summary>
    public static void AssignSaveFileDirAndFileNameOnLoad(string parsedSaveFileName)
    {
        SaveFileSelected = parsedSaveFileName.Trim('\r', '\n'); //c:\saves\ must ONLY contain save files created by IdleArchitects
    }
    /// <summary>
    /// ASSIGN FILE DIR & FILE NAME & FILE SELECTED VARS IF NEW GAME
    /// </summary>
    public static void AssignSaveFileDirAndFileNameOnNew()
    {
        if (Directory.Exists(@"c:\saves\"))
        {
            SaveFileDir = @"c:\saves\"; //c:\saves\ must ONLY contain save files created by IdleArchitects
            Debug.Log("dir does exist");
        }
        else
        {
            Directory.CreateDirectory(@"c:\saves\"); //create dir 
            SaveFileDir = @"c:\saves\"; //c:\saves\ must ONLY contain save files created by IdleArchitects
            Debug.Log(@"dir does not exist, creating 'c:\saves\' ");
        }
        string[] files = Directory.GetFiles(SaveFileDir);
        int i = 0;
        var sb2 = new System.Text.StringBuilder();
        string newSaveFileName = string.Empty;
        string newSaveFileNameTemp = string.Empty;
        if (files.Length > 0)
        {
            foreach (string file in files)
            {
                i++;
                if (i >= 0 && i < 10)
                {
                    sb2.Clear();
                    newSaveFileName = file.Substring(9);
                    newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                    sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                    newSaveFileName = sb2.ToString().Remove(18);
                }
                else if (i > 9 && i < 100)
                {
                    sb2.Clear();
                    newSaveFileName = file.Substring(9);
                    newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                    sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                    newSaveFileName = sb2.ToString().Remove(18 + 1);
                }
                else if (i >= 100 && i < 1000)
                {
                    sb2.Clear();
                    newSaveFileName = file.Substring(9);
                    newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                    sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                    newSaveFileName = sb2.ToString().Remove(18 + 2);
                }
                else if (i >= 1000 && i < 10000)
                {
                    sb2.Clear();
                    newSaveFileName = file.Substring(9);
                    newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                    sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                    newSaveFileName = sb2.ToString().Remove(18 + 3);
                }
                else if (i >= 10000 && i < 100000)
                {
                    sb2.Clear();
                    newSaveFileName = file.Substring(9);
                    newSaveFileNameTemp = newSaveFileName.Remove((newSaveFileName.Length - 5));
                    sb2.AppendFormat("{0}{1}{2}", newSaveFileNameTemp, (i + 1).ToString(), ".txt").AppendLine();
                    newSaveFileName = sb2.ToString().Remove(18 + 4);
                    Debug.Log("BETWEEN 10k - 100k FILES EXIST IN C:\\saves\\ - consider culling save entires"); //can handle up to 10k save files | also cannot handle non {save}.txt files. leave them out of this directory for now
                }

            }
        }
        else if (files.Length == 0) // if no files exist in c:\saves\
        {
            newSaveFileName = "saveTestFile1.txt";
        }
        SaveFileName = newSaveFileName;
        SaveFileSelected = saveFileDir.Trim('\r', '\n') + saveFileName.Trim('\r', '\n');
    }


}
