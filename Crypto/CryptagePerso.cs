using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CryptagePerso
{

	private string _texte, _cle;
	public CryptagePerso(string Texte, string Cle)
	{
		this._texte = Texte;
		this._cle = Cle;
	}

	public string executer(bool decrypter)
	{
		if (decrypter)
		{
			string cle = this._cle;
			this._texte = enleverSel();

			this._cle = cle;
			return cryptage(decrypter);
		}

		this._texte = cryptage(decrypter);

		return ajouterSel();
	}

	private string cryptage(bool decrypter)
	{
		Console.WriteLine("Texte appellé avec Cryptage : {0}\nClé de cryptage : {1}", this._texte, this._cle);
		List<char> result = new List<char>();
		int cleindex = 0;
		for (int i = 0; i < _texte.Length; i++)
		{
			int key;
			if (cleindex >= _cle.Length)
			{
				cleindex = 0;
			}
			key = (int)Char.GetNumericValue(this._cle[cleindex]);
			if (key == -1)
			{
				key = (int)this._cle[cleindex];
			}

			char ch = this._texte[i];

			if (decrypter)
			{
				key *= -1;
			}

			int val = (int)ch + key;
			result.Add((char)val);
			cleindex++;
		}

		string resultStr = new string(result.ToArray());

		Console.WriteLine("Résultat de Cryptage : {0}", resultStr);
		return resultStr;
	}

	private string enleverSel()
	{
		string selUn = this._texte.Substring(0, 3);
		Console.WriteLine("Sel gauche : {0}", selUn);
		string selDeux = this._texte.Substring(this._texte.Length - 3);
		Console.WriteLine("Sel droite : {0}", selDeux);
		string sel = selUn + selDeux;
		Console.WriteLine("Sel : {0}", sel);
		this._texte = this._texte.Substring(3, this._texte.Length - 6);
		Console.WriteLine("Texte sans sel à décrypter : {0}", this._texte);
		this._cle = sel;

		return cryptage(true);
	}

	private string ajouterSel()
	{
		string sel = genereSel();
		Console.WriteLine("Sel généré : {0}", sel);
		string selUn = sel.Substring(0, 3);
		Console.WriteLine("Sel gauche : {0}", selUn);
		string selDeux = sel.Substring(3);
		Console.WriteLine("Sel droite : {0}", selDeux);
		this._cle = sel;
		string encoded = cryptage(false);
		return selUn + encoded + selDeux;
	}

	private string genereSel()
	{
		Random aleatoire = new Random();
		string sel = "";
		for (int i = 0; i < 6; i++)
		{
			int num = aleatoire.Next(0, 26);
			char lettre = Convert.ToChar(num + 65);
			sel += lettre;
		}
		return sel;
	}
}