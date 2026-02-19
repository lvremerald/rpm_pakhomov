import pandas as pd
print("Введите полное имя файла (напр. \"C:\\Users\\Admin\\Desktop\\file.xlsx): ")
fileName = ""
input(fileName)
fileName.strip()
fileName.replace("\"", "")
try :
    df = pd.read_excel(fileName, sheet_name=['Лист1','Лист2'])
except:
    print("Файл не найден")
    quit
print(df['Лист1'])
print("")
print(df['Лист2'])