// Menú principal

Console.WriteLine("¿Qué juego quieres jugar?");

Console.WriteLine("  1 — Ahorcado");

Console.Write("Opción: ");

var opcion = Console.ReadLine();



if (opcion == "1")

{

    // --- LÓGICA DEL AHORCADO ---

    var repositorio = new Ahorcado.PalabrasEnMemoria();

    var motor = new Ahorcado.MotorAhorcado(repositorio);

    var ui = new Ahorcado.ConsolaUI(motor);



    Console.WriteLine("=== AHORCADO ===");



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



    // Nota: El código original de 'PreguntarOtraVez' solo instanciaba

    // pero no reiniciaba el bucle. Aquí se mantiene igual a tu fragmento.

    if (ui.PreguntarOtraVez())

    {

        var nuevoMotor = new Ahorcado.MotorAhorcado(repositorio);

        var nuevaUI = new Ahorcado.ConsolaUI(nuevoMotor);

    }

}


