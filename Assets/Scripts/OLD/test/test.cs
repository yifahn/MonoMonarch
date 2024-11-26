using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using UnityNpgsql;
using System;
public class test : MonoBehaviour
{
    public void testing()//s
    {

        string name ="TEST";
        
        var connString = "Server=localhost;Port=5432;User Id=postgres;_password=password;Database=test";

        using (NpgsqlConnection connection = new NpgsqlConnection(connString))
        {
            connection.Open();
            //insert into table test2 - already is setup to auto increment PK - only req. name column
            string insertQuery = $"INSERT INTO test2 (name) VALUES ('{name}')";

            using (NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection))
            {
                command.ExecuteNonQuery();
            }

            connection.Close();//ssssssssssss
        }

    }
}

