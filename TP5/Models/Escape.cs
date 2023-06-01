public static class Escape{
public static string[] incognitasSalas = new string[4] {"a","b","c","d"} ;
static int estadoJuego = 1;

public static int GetEstadoJuego(){
    return estadoJuego;
}

public static bool ResolverSala(int Sala, string Incognita){
bool Paso = incognitasSalas[Sala-1] == Incognita;
if(Paso){estadoJuego++;}
return Paso;
}
}