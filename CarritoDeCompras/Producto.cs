using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    internal class Producto
    {
        private int id;
        private String nombre;
        private double precioUnitario;
        private int cantidad;
        public Producto(int id, String nombre, double precioUnitario, int cantidad)
        {
            this.id = id;
            this.nombre = nombre;
            this.precioUnitario = precioUnitario;
            this.cantidad = cantidad;
        }

        public int getId() { return id; }

        public String getNombre() { return nombre; }

        public double getPrecioUnitario() { return precioUnitario; }

        public bool mismoNombre(String nombre) { return this.nombre.Equals(nombre); }

        public void sumarStock(int cantidad) { this.setCantidad(this.getCantidad() + cantidad); }

        public void restarStock(int cantidad) { this.setCantidad(this.getCantidad() - cantidad); }

        public int getCantidad()
        {
            return cantidad;
        }

        public void setCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }

        public void sumarCantidad(int cantidad) { setCantidad(this.cantidad + cantidad); }

        public override String ToString()
        {
            return "Producto [id = "+ id + ", nombre = " + nombre + ", precioUnitario = " + precioUnitario + ", Stock = " + cantidad + "]";
        }

        public double getSubtotal() { return cantidad * precioUnitario; }
    }
}
