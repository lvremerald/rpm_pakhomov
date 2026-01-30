print('Лабораторная работа №1.')
list1 = [1, 2, 3, 1, 'bread', 0.69, 'cornball', 'bread', 3, 0]
print(f"Список: {list1}")
print(f"Последний элемент списка: {list1[-1]}")
print(f"2-й, 3-й и 6-й элементы: {list1[1]}, {list1[2]}, {list1[5]}")
list1[2] = 0
print(f"3-й элемент теперь {list1[2]}")
print(f"Элементы с 5-го по 8-й: {list1[4:7]}")
list1.append(68)
print(f"Новый 11-й элемент списка: {list1[10]}")
list1.insert(5, 'middle')
print(f"Новый 6-й элемент: {list1[5]}")
print(f"Единиц в списке: {list1.count(1)}")
list2 = list1.copy()
print("list2 - копия списка list1")
list1[7] = 'change'
print(f"Новый 8-1 элемент первого списка: {list1[7]}")
print(f"Первый список: {list1}")
print(f"Второй список: {list2}")