import mysql.connector
import os
import asyncio

def executequeries():
    conn = mysql.connector.connect(host="localhost", database="catalogodb", user="Iuri", password="261117")

    arquivos = list(filter(lambda x: x[len(x) - 3::] == "sql", os.listdir(r"C:\Users\Iuri\Desktop\WebAPI\LearningApi\DataBase")))

    for arquivo in arquivos:
        with open(arquivo, "r") as sql_file:
            for line in sql_file.readlines():
                sql = line
                cursor = conn.cursor()
                cursor.execute(sql)
                conn.commit()
                cursor.close()
    conn.close()

executequeries()



