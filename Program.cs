// Menú principal

Console.Clear();
Console.Title = "Ahorcado y Viborita";

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("========================================");
Console.WriteLine("          MENU DE JUEGOS");
Console.WriteLine("========================================");
Console.ResetColor();

Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Selecciona una opcion:");
Console.ResetColor();

Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("  [1] Ahorcado");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("  [2] Viborita");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("  [Q] Salir");
Console.ResetColor();

Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.Write("Opcion: ");
Console.ResetColor();

var opcion = Console.ReadLine()?.ToLower();

if (opcion == "1")
{
    // --- LÓGICA DEL AHORCADO ---

    var repositorio = new Ahorcado.PalabrasEnMemoria();
    var motor = new Ahorcado.MotorAhorcado(repositorio);
    var ui = new Ahorcado.ConsolaUI(motor);

    Console.Clear();

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        char letra = ui.PedirLetra();

        if (motor.LetraYaUsada(letra))
        {
            ui.MostrarMensaje("Ya usaste esa letra.");
            continue;
        }

        motor.RegistrarLetra(letra);
    }

    ui.MostrarTablero();

    if (motor.Ganado())
        ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
    else
        ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");

    if (ui.PreguntarOtraVez())
    {
        var nuevoMotor = new Ahorcado.MotorAhorcado(repositorio);
        var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);
    }
}
else if (opcion == "2")
{
    // --- LÓGICA DE LA VIBORITA ---

    var motor = new Ahorcado.MotorViborita();
    var ui = new Ahorcado.ConsolaUIViborita(motor);

    Console.Clear();
    Console.CursorVisible = false;

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        var tecla = ui.LeerTecla();

        if (tecla == ConsoleKey.Q)
            break;

        if (tecla != ConsoleKey.NoName)
            motor.CambiarDireccion(tecla);

        motor.Avanzar();

        Thread.Sleep(150);
    }

    ui.MostrarTablero();

    ui.MostrarMensaje(motor.Ganado()
        ? "\n¡Ganaste! Llegaste a 10 puntos."
        : "\nGame over.");

    Console.CursorVisible = true;
}
else if (opcion == "q")
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("\nSaliendo del juego...");
    Console.ResetColor();
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nOpcion no valida.");
    Console.ResetColor();
}
