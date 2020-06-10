using System;

namespace praktika_9
{
    class TwoList
    {
        public int data;//информационное поле
        public TwoList next,
            pred;//адрес предыдущего элемента
        public TwoList(int d)
        {
            data = d;
            next = null;
            pred = null;
        }
        public override string ToString()
        {
            return data + " ";
        }
        static TwoList MakeTwoList(int d)
        {
            TwoList p = new TwoList(d);
            return p;
        }
        public static TwoList MakeList(int size) //добавление в начало
        {
            int info = 1;
            TwoList beg = MakeTwoList(info);
            TwoList r = beg;//переменная хранит адрес конца списка 
            for (int i = 2; i <= size; i++)
            {
                info = i;
                TwoList p = MakeTwoList(info);
                r.next = p;
                p.pred = r;
                r = p;
            }
            return beg;
        }
        static public void PrintList(TwoList beg)
        {
            if (beg == null)
            {
                Console.WriteLine("Список пустой!");
                return;
            }
            TwoList currentPoint = beg;
            while (currentPoint != null)
            {
                Console.Write(currentPoint.ToString());
                currentPoint = currentPoint.next;
            }
            Console.WriteLine();
        }
        public bool Contains(int data, TwoList beg)
        {
            TwoList current = beg;
            if (current == null) return false;
            do
            {
                if (current.data == data)
                    return true;
                current = current.next;
            }
            while (current != null);
            return false;
        }
        static public TwoList DelElement(TwoList beg, int number)
        {
            if (beg == null)//пустой список
            {
                Console.WriteLine("Ошибка! Список пустой!");
                return null;
            }
            if (number == 1)//удаляем первый элемент
            {
                beg = beg.next;
                return beg;
            }
            TwoList p = beg;
            //ищем элемент для удаления и встаем на предыдущий
            for (int i = 1; i < number && p != null; i++)
                p = p.next;
            if (p == null)//если элемент не найден
            {
                Console.WriteLine("Элемент не найден!");
                return beg;
            }
            //исключаем элемент из списка
            p.next = p.next.next;
            return beg;
        }
    }
    class Program
    {
        static public int InputNumber(string ForUser, int left = 1, int right = int.MaxValue)
        {
            bool ok = true;
            int number = 0;
            do
            {
                Console.WriteLine(ForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number <= right) ok = false;
                    else
                    {
                        Console.WriteLine("Введите число от {0} до {1}!", left, right);
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный ввод числа!");
                }
            } while (ok);
            return number;
        }
        static void Main(string[] args)
        {
            int n = InputNumber("Введите число N: ");
            TwoList beg = null;
            beg = TwoList.MakeList(n);
            TwoList.PrintList(beg);
            int find = InputNumber("Введите значение элемента, которое хотите найти: ");
            bool ok = beg.Contains(find, beg);
            if (ok) Console.WriteLine("Элемент был найден!");
            else Console.WriteLine("Элемент не найден!");
            find = InputNumber("Введите значение элемента, которое хотите удалить: ");
            beg = TwoList.DelElement(beg, find);
            TwoList.PrintList(beg);
            Console.ReadKey();
        }
    }
}
