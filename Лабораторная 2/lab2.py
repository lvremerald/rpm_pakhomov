class Employee: # работник
    def __init__(self, surname, name, father_name, salary, profession):
        self.surname = surname # фамилия
        self.name = name # имя
        self.father_name = father_name # отчество
        self.salary = salary # зарплата
        self.profession = profession # профессия
    def display_info(self):
        print(f"{self.surname} {self.name}, {self.profession}\nЗаработная плата - {self.salary} руб/месяц.")
class Programmer(Employee): # программист
    def __init__(self, surname, name, father_name, salary, profession, grade, team):
        super().__init__(surname, name, father_name, salary, profession)
        self.grade = grade # уровень
        self.team = team # команда
class Manager(Employee): # начальник
    def __init__(self, surname, name, father_name, salary, profession, position):
        super().__init__(surname, name, father_name, salary, profession)
        self.position = position # позиция

class Building: # здание
    def __init__(self, purpose, floors, area):
        self.purpose = purpose
        self.floors = floors
        self.area = area
    def display_info(self):
        print(f"{self.purpose}\nЭтажей - {self.floors}, Площадь - {self.area} м^2.")
class House(Building): # частный дом
    def __init__(self, purpose, floors, area, inner_area, room_count):
        super().__init__(purpose, floors, area)
        self.inner_area = inner_area
        self.room_count = room_count
class ApartmentComplex(Building): # многоквартирный дом
    def __init__(self, purpose, floors, area, apartment_count):
        super().__init__(purpose, floors, area)
        self.apartment_count = apartment_count


#Содадим объекты классов и вызовем метод display_info() для вывода информации:

employee1 = Manager("Петров", "Иван", "Ильич", 120000, "Руководитель", "Начальник тестирования") # сначала первые пять полей передаются в класс Employee, потом из него передаются в наследованный класс Manager, и потом в него передается оставшееся поле
employee2 = Programmer("Диванов", "Пётр", "Васильевич", 35000, "Программист", "Junior", "Отдел тестирования") # первые пять идут в Employee, из него в Programmer и потом остальные два

employee1.display_info()
employee2.display_info()

building1 = House("Жилой дом", 2, 121, 100, 3)
building2 = ApartmentComplex("ЖК", 10, 400, 80)

building1.display_info()
building2.display_info()