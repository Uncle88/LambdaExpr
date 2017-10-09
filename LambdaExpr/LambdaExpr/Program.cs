using System;

namespace NewAnonimousLambdaExpr
{
	public delegate int Square(int a);
	public delegate int AccountLogin(string a);
	public delegate bool IsValidPassword(string str1, string str2);

	public delegate void CustomDelegate<T>(T Tvalue);

	class MainClass
	{
		public static void Main(string[] args)
		{
			Square sq = (a) => a * a;
			int rez = sq(5);
			Console.WriteLine(rez);

			LoginService.SetLogin();
			LoginService.SetPassword();

			CustomDelegate<int> cd = (int Tvalue) => Console.WriteLine(Tvalue);
			cd(11111);

			CustomDelegate<double> cd2 = (double Tvalue) => Console.WriteLine(Tvalue + 2);
			cd2(0.1);

			CustomDelegate<string> cd3 = (string Tvalue) => Console.WriteLine(Tvalue.IndexOf('a'));
			cd3("aaa");
		}
	}

	public class LoginService
	{
		public static void SetLogin()
		{
			Console.WriteLine("\n");
			//input login
			string _login = Console.ReadLine();

			AccountLogin accountLoginDelegate = s => s.Length;
			int loginLength = accountLoginDelegate(_login);

			if (loginLength > 20 || loginLength < 1)
			{
				Console.WriteLine("Not valid login");
				// рекурсия на этот же метод для повторного ввода логина
				SetLogin();
			}
			Console.WriteLine(loginLength);
		}

		public static void SetPassword()
		{
			Console.WriteLine("\n");
			//inpun password and repit
			string pass1 = Console.ReadLine();
			Console.WriteLine("\n");
			string pass2 = Console.ReadLine();

			IsValidPassword vp = (str1, str2) => str1 == str2;

			if (vp(pass1, pass2))
			{
				Console.WriteLine("success registration");
			}
			else
				Console.WriteLine("not success registration");
		}
	}
}

