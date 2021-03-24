using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokerageLib
{
	public class NumberAnalyzer
	{
		private int _candidateNumber;

		public NumberAnalyzer(int candidateNumber)
		{
			_candidateNumber = candidateNumber;
		}
		public bool ContainsOddDigit()
		{
			int temp;
			var candidateString = _candidateNumber.ToString();

			foreach (char theChar in candidateString)
			{

				temp = (int)theChar;
				if (temp % 2 == 1)
				{
					return true;
				}
			}
			return false;
		}
		public int GetTheCountOfThisDigit(int digit)
		{
			int temp = _candidateNumber;
			List<int> digits = new List<int>();
			while (temp > 0)
			{
				digits.Add(temp % 10);
				temp = temp / 10;
			}


			return digits.Where(x => x == digit).Count();
		}

	}
}
