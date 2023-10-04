Mazo mazo = new Mazo();
Console.WriteLine("Mazo creado");
foreach (Carta carta in mazo.cartas)
{
    Console.WriteLine("Carta: " + carta.Nombre + " de " + carta.Pinta + " con valor de " + carta.Val);
}
mazo.reparto();
Console.WriteLine("Mazo repartido");
foreach (Carta carta in mazo.cartas)
{
    Console.WriteLine("Carta: " + carta.Nombre + " de " + carta.Pinta + " con valor de " + carta.Val);
}
Console.WriteLine("Mazo reinicio");
mazo.Reinicio();
foreach (Carta carta in mazo.cartas)
{
    Console.WriteLine("Carta: " + carta.Nombre + " de " + carta.Pinta + " con valor de " + carta.Val);
}
mazo.Revolver();
Console.WriteLine("Mazo revolvido");
foreach (Carta carta in mazo.cartas)
{
    Console.WriteLine("Carta: " + carta.Nombre + " de " + carta.Pinta + " con valor de " + carta.Val);
}
Jugador jugador = new Jugador("Jugador 1");
Console.WriteLine("Jugador creado");
Console.WriteLine("Jugador roba cartas");
jugador.Robar(mazo);
jugador.Robar(mazo);
jugador.Robar(mazo);
foreach (Carta carta in jugador.Mano)
{
    Console.WriteLine("Carta: " + carta.Nombre + " de " + carta.Pinta + " con valor de " + carta.Val);
}
Console.WriteLine("Jugador descarta cartas");
jugador.Descartar(5);
foreach (Carta carta in jugador.Mano)
{
    Console.WriteLine("Carta: " + carta.Nombre + " de " + carta.Pinta + " con valor de " + carta.Val);
}
Console.WriteLine("Jugador descarta cartas 2");
jugador.Descartar(1);
foreach (Carta carta in jugador.Mano)
{
    Console.WriteLine("Carta: " + carta.Nombre + " de " + carta.Pinta + " con valor de " + carta.Val);
}
class Carta
{
    public string Nombre;
    public string Pinta;
    public int Val;
    public Carta(string nombre, string pinta, int val)
    {
        Nombre = nombre;
        Pinta = pinta;
        Val = val;
    }
    public void Print()
    {
        Console.WriteLine("Nombre: " + Nombre);
        Console.WriteLine("Pinta: " + Pinta);
        Console.WriteLine("Valor: " + Val);
    }
}

class Mazo
{
    public List<Carta> cartas;

    public Mazo()
    {
        cartas = new List<Carta>();
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                string nombre = "";
                string pinta = "";
                int val = 0;
                switch (i)
                {
                    case 1:
                        pinta = "Tréboles";
                        break;
                    case 2:
                        pinta = "Picas";
                        break;
                    case 3:
                        pinta = "Corazones";
                        break;
                    case 4:
                        pinta = "Diamantes";
                        break;
                }
                switch (j)
                {
                    case 1:
                        nombre = "As";
                        val = 1;
                        break;
                    case 11:
                        nombre = "J";
                        val = 11;
                        break;
                    case 12:
                        nombre = "Reina";
                        val = 12;
                        break;
                    case 13:
                        nombre = "Rey";
                        val = 13;
                        break;
                    default:
                        nombre = j.ToString();
                        val = j;
                        break;
                }
                Carta carta = new Carta(nombre, pinta, val);
                cartas.Add(carta);
            }
        }
    }

    public Carta reparto()
    {
        Random random = new Random();
        int index = random.Next(0, cartas.Count);
        Carta carta = cartas[index];
        cartas.RemoveAt(index);
        return carta;
    }

    public void Reinicio()
    {
        cartas.Clear();
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 1; j <= 13; j++)
            {
                string nombre = "";
                string pinta = "";
                int val = 0;
                switch (i)
                {
                    case 1:
                        pinta = "Tréboles";
                        break;
                    case 2:
                        pinta = "Picas";
                        break;
                    case 3:
                        pinta = "Corazones";
                        break;
                    case 4:
                        pinta = "Diamantes";
                        break;
                }
                switch (j)
                {
                    case 1:
                        nombre = "As";
                        val = 1;
                        break;
                    case 11:
                        nombre = "J";
                        val = 11;
                        break;
                    case 12:
                        nombre = "Reina";
                        val = 12;
                        break;
                    case 13:
                        nombre = "Rey";
                        val = 13;
                        break;
                    default:
                        nombre = j.ToString();
                        val = j;
                        break;
                }
                Carta carta = new Carta(nombre, pinta, val);
                cartas.Add(carta);
            }
        }
    }

    public void Revolver()
    {
        Random rnd = new Random();
        cartas.Sort((x, y) => rnd.Next(-1, 2));
    }
}

class Jugador
{
    public string Nombre;
    public List<Carta> Mano;
    public Jugador(string nombre)
    {
        Nombre = nombre;
        Mano = new List<Carta>();
    }
    public void Robar(Mazo mazo)
    {
        Carta carta = mazo.reparto();
        Mano.Add(carta);
    }
    public Carta Descartar(int index)
    {
        if (index >= Mano.Count)
        {
            Console.WriteLine("No se puede descartar esa carta");
            return null;
        }
        else
        {
            Carta carta = Mano[index];
            Mano.RemoveAt(index);
            return carta;
        }

    }
}