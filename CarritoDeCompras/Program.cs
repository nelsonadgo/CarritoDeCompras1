using System;
using System.Runtime.CompilerServices;

namespace CarritoDeCompras
{
    internal class Program
    {
        private static Sistema sistema = new Sistema("Vendo todo S.A.");

        private static void mostrarResultadoPrueba(bool resultado)
        {
            if (resultado)
            {
                Console.WriteLine("Prueba Exitosa.");
            }
            else
            {
                Console.WriteLine("### OJO Prueba Fallida ###");
            }
        }
        
        private static void evaluarResultadoEsperado(bool resultado, bool resultadoEsperado)
        {
            Console.WriteLine("Resultado obtenido:  " + resultado + "resultado esperado:  " +  resultadoEsperado);
            mostrarResultadoPrueba(resultado == resultadoEsperado);
        }

        private static void evaluarResultadoEsperado(string resultado, string resultadoEsperado)
        {
            Console.WriteLine("Resultado obtenido: " + resultado + "resultado esperado: " + resultadoEsperado);
            mostrarResultadoPrueba(resultado == resultadoEsperado);
        }

        private static void probarRegistrarProducto(String nombre, double precioUnitario, int stockInincial, bool resultadoEsperado)
        {
            Console.WriteLine("Probando registrar nombre: " + nombre + " precio Unitario: " + precioUnitario + " Stock Inicial: " + stockInincial);
            evaluarResultadoEsperado(sistema.registrarProducto(nombre, precioUnitario, stockInincial), resultadoEsperado);
        }

        private static void probarIniciarCompra(String dni, bool resultadoEsperado)
        {
            Console.WriteLine("Probando Iniciar Compra con DNI: " + dni);
            evaluarResultadoEsperado(sistema.iniciarCompra(dni), resultadoEsperado);
        }

        private static void probarAgregarProductoCarrito(String nombre, int cantidad, string resultadoEsperado)
        {
            Console.WriteLine("Probando agregar producto al carrito nombre: " + nombre + " cantidad: " + cantidad);
            evaluarResultadoEsperado(sistema.agregarProductoCarrito(nombre, cantidad), resultadoEsperado);
        }

        private static void probarFinalizarCompra(bool resultadoEsperado)
        {
            Console.WriteLine("Probando Finalizar Compra");
            evaluarResultadoEsperado(sistema.finalizarCompra(), resultadoEsperado);
        }

        private static void probarDescartarCompra(bool resultadoEsperado)
        {
            Console.WriteLine("Probando descartar compra");
            evaluarResultadoEsperado(sistema.descartarCompra(), resultadoEsperado);
        }

        private static void Main(String[] args)
        {
            probarRegistrarProducto("TV", 10000, 2, true);
            probarRegistrarProducto("TV", 10000, 2, false);
            probarRegistrarProducto("Radio", 600, -1, false);
            probarRegistrarProducto("Radio", 600, 1, true);

            probarAgregarProductoCarrito("TV", 1, "Compra_No_Iniciada");

            probarIniciarCompra("26666666", true);
            probarIniciarCompra("26666666", false);

            probarAgregarProductoCarrito("TV", 10, "NO_AHY_STOCK");
            probarAgregarProductoCarrito("Bicicleta", 1, "PRODUCTO_INVALIDO");

            probarAgregarProductoCarrito("TV", 1, "AGREGAR_OK");
            probarAgregarProductoCarrito("Radio", 1, "AGREAGR_OK");
            probarAgregarProductoCarrito("Radio", 1, "NO_HAY_STOCK");

            probarFinalizarCompra(true);
            probarFinalizarCompra(false);

            probarIniciarCompra("26666667", true);
            probarAgregarProductoCarrito("Radio", 1, "NO_HAY_STOCK");
            probarAgregarProductoCarrito("TV", 1, "AGREGAR_OK");

            probarDescartarCompra(true);
            probarDescartarCompra(false);

            probarIniciarCompra("26666667", true);
            probarAgregarProductoCarrito("TV", 1, "AGREGAR_OK");
            probarFinalizarCompra(true);




        }
    }
}