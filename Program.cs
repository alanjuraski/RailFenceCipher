// See https://aka.ms/new-console-template for more information
using System.Collections;








//***************************************************************************************

// PARAMETROS DE ENTRADA 

string digitado = string.Empty;
int trilhos = 0;



digitado = "WE ARE DISCOVERED. FLEE AT ONCE";
trilhos = 3;
//linhas = 7;

//digitado = "WE ARE DISCOVERED. RUN AT ONCE";
//linhas = 3;

//digitado = "DEVELOPER SENIOR. CODE GROUP";
//linhas = 7;



const bool DEBUG_PASSO_A_PASSO = false;

//***************************************************************************************


Console.WriteLine(" ");Console.WriteLine(" ");Console.WriteLine(" digitado:  " + digitado);Console.WriteLine(" ");


string inicioTratado = digitado.Replace(" ", "").Replace(".", "");

string criptografado = Criptografa(inicioTratado, trilhos);

string descriptografado = DesCriptografa(criptografado, trilhos);


if (descriptografado == inicioTratado)
{
    Console.WriteLine(" ");
    Console.WriteLine("CORRETO! A palavra de saída é *** IGUAL *** da palavra de entrada!");
    Console.WriteLine(" ");
}
else
{
    Console.WriteLine("Erro. A palavra de saída é DIFERENTE da palavra de entrada");
    Console.WriteLine(" ");
}




    static string Criptografa(string inicio, int p_trilhos )
    {

        string finalPalavra = string.Empty;

        int totalLinhas = p_trilhos;
        int quallLinha = 0;
        bool sobe = false;
        bool desce = true;
        List<string> list = new List<string>();
    
    
        for(int i=0; i< totalLinhas; i++)
        {
            list.Add(string.Empty);
        }
    
        if(list.Count>0)
        {
            quallLinha = 0;

            for (int i = 0; i < inicio.Count(); i++)
            {
                if (quallLinha == 0)
                {
                    list[quallLinha] = list[quallLinha] + inicio[i].ToString();

                    if (DEBUG_PASSO_A_PASSO)
                    {
                        Console.WriteLine("I : " + inicio[i].ToString());
                        Console.WriteLine("");
                        Console.WriteLine("p" + quallLinha + " : " + list[quallLinha]);
                        Console.WriteLine("");
                    }

                    sobe = false;
                    desce = true;

                    quallLinha++;
                }
                else if ( ! (quallLinha == (totalLinhas-1))
                    &&    ! ( quallLinha == 0 )
                        )
                {
                    list[quallLinha] = list[quallLinha] + inicio[i].ToString();

                    if (DEBUG_PASSO_A_PASSO)
                    {
                        Console.WriteLine("I : " + inicio[i].ToString());
                        Console.WriteLine("");
                        Console.WriteLine("p" + quallLinha + " : " + list[quallLinha]);
                        Console.WriteLine("");
                    }

                    if (sobe == false && desce == true)
                    {
                        quallLinha++;
                    }
                    else if (sobe == true && desce == false)
                    {
                        quallLinha--;
                    }


                }
                else if (quallLinha == (totalLinhas - 1))
                {
                    list[quallLinha] = list[quallLinha] + inicio[i].ToString();

                    if (DEBUG_PASSO_A_PASSO)
                    {
                        Console.WriteLine("I : " + inicio[i].ToString());
                        Console.WriteLine("");
                        Console.WriteLine("p" + quallLinha + " : " + list[quallLinha]);
                        Console.WriteLine("");
                    }

                    sobe = true;
                    desce = false;
                    quallLinha--;
                }
            }


            int contadorFor = 0;
            foreach(var item in list)
            {
                finalPalavra = finalPalavra + item.ToString();
                contadorFor++;

                if (DEBUG_PASSO_A_PASSO)
                {
                    Console.WriteLine("item" + contadorFor + ": " + item.ToString());
                    Console.WriteLine("");
                }
            }        
        }
        else
        {
            finalPalavra = string.Empty;
        }

        Console.WriteLine("Com " + p_trilhos + " trilho(s) a palavra codificada é: " + finalPalavra);
        Console.WriteLine("");

        return finalPalavra;
    }

    static string DesCriptografa(string inicio, int p_trilhos)
    {


        string finalPalavra = string.Empty;

        int totalLinhas = p_trilhos;
        int quallLinha = 0;
        bool sobe = false;
        bool desce = true;

        List<string> listSubtrings = new List<string>();
        List<int> listPassou = new List<int>();


        for (int i = 0; i < totalLinhas; i++)
        {
            listPassou.Add(0);
        }

        if (listPassou.Count > 0)
        {
            quallLinha = 0;

            for (int i = 0; i < inicio.Count(); i++)
            {
                if (quallLinha == 0)
                {
                    listPassou[quallLinha] = listPassou[quallLinha] + 1;

                    sobe = false;
                    desce = true;
                    quallLinha++;

                }
                else if (!(quallLinha == (totalLinhas - 1))
                    && !(quallLinha == 0)
                        )
                {
                    listPassou[quallLinha] = listPassou[quallLinha] + 1;

                    if (sobe == false && desce == true)
                    {
                        quallLinha++;
                    }
                    else if (sobe == true && desce == false)
                    {
                        quallLinha--;
                    }
                }
                else if (quallLinha == (totalLinhas - 1))
                {
                    listPassou[quallLinha] = listPassou[quallLinha] + 1;

                    sobe = true;
                    desce = false;
                    quallLinha--;
                }
            }

            if (inicio.Count() > 0)
            {
                int indexInicioSubString = 0;
                foreach (var tamanhoDaSubString in listPassou)
                {
                    listSubtrings.Add(inicio.Substring(indexInicioSubString, tamanhoDaSubString));
                    indexInicioSubString = indexInicioSubString + tamanhoDaSubString;

                }
            }

            if (listSubtrings.Count > 0)
            {
                quallLinha = 0;

                for (int i = 0; i < inicio.Count(); i++)
                {
                    if (quallLinha == 0)
                    {
                        if (listSubtrings[quallLinha].Length > 0)
                        {
                            finalPalavra = finalPalavra + listSubtrings[quallLinha].Substring(0, 1);
                            listSubtrings[quallLinha] = listSubtrings[quallLinha].Remove(0, 1);
                        }

                        if (DEBUG_PASSO_A_PASSO)
                        {
                            Console.WriteLine("I : " + finalPalavra[i].ToString());
                            Console.WriteLine("");
                            Console.WriteLine("p" + quallLinha + " : " + listSubtrings[quallLinha]);
                            Console.WriteLine("");
                        }

                        sobe = false;
                        desce = true;

                        quallLinha++;
                    }
                    else if (!(quallLinha == (totalLinhas - 1))
                        && !(quallLinha == 0)
                            )
                    {
                        if (listSubtrings[quallLinha].Length > 0)
                        {
                            finalPalavra = finalPalavra + listSubtrings[quallLinha].Substring(0, 1);
                            listSubtrings[quallLinha] = listSubtrings[quallLinha].Remove(0, 1);
                        }
                        if (DEBUG_PASSO_A_PASSO)
                        {
                            Console.WriteLine("I : " + finalPalavra[i].ToString());
                            Console.WriteLine("");
                            Console.WriteLine("p" + quallLinha + " : " + listSubtrings[quallLinha]);
                            Console.WriteLine("");
                        }

                        if (sobe == false && desce == true)
                        {
                            quallLinha++;
                        }
                        else if (sobe == true && desce == false)
                        {
                            quallLinha--;
                        }
                    }
                    else if (quallLinha == (totalLinhas - 1))
                    {
                        if (listSubtrings[quallLinha].Length > 0)
                        {
                            finalPalavra = finalPalavra + listSubtrings[quallLinha].Substring(0, 1);
                            listSubtrings[quallLinha] = listSubtrings[quallLinha].Remove(0, 1);
                        }

                        if (DEBUG_PASSO_A_PASSO)
                        {
                            Console.WriteLine("I : " + finalPalavra[i].ToString());
                            Console.WriteLine("");
                            Console.WriteLine("p" + quallLinha + " : " + listSubtrings[quallLinha]);
                            Console.WriteLine("");
                        }

                        sobe = true;
                        desce = false;
                        quallLinha--;
                    }
                }
            }
        }
        else
        {
            finalPalavra = string.Empty;
        }

        Console.WriteLine("                     -> decodificada é: " + finalPalavra);
        Console.WriteLine("");

        return finalPalavra;
    }

