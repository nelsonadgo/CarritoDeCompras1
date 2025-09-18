using System;
using System.Collections.Generic;
using System.Text;

namespace CarritoDeCompras
{
    internal class Sistema
    {
        private string razonSocial;
        private List<Producto> productos;
        private Carrito carrito;
        private int idUltimoCarrito;
        private int idUltimoProducto;

        public Sistema(string razonSocial)
        {
            this.razonSocial = razonSocial;
            this.productos = new List<Producto>();
            this.idUltimoCarrito = 0;
            this.idUltimoProducto = 0;
        }

        public bool iniciarCompra(string dni)
        {
            bool pudoIniciar = false;
            if (carrito == null)
            {
               carrito = new Carrito(dni, ++this.idUltimoCarrito);
                pudoIniciar = true;
            }
            return pudoIniciar;
        }

        private Producto buscarProducto(string nombre)
        {
            Producto productoABuscar = null;
            int i = 0;
            while (i < productos.Count && productoABuscar == null)
            {
                if (productos[i].mismoNombre(nombre))
                {
                    productoABuscar = productos[i];
                }
                else
                {
                    i++;
                }
            }
            return productoABuscar;
        }

        public bool registrarProducto(String nombre, double precioUnitario, int stockInicial)
        {
            bool pudoRegistrar = false;
            if (buscarProducto(nombre) == null && stockInicial >= 0)
            {
                productos.Add(new Producto(++this.idUltimoProducto, nombre, precioUnitario, stockInicial));
                pudoRegistrar = true;
            }            
            return pudoRegistrar;
        }

        public string agregarProductoCarrito(String nombre, int cantidad)
        {
            string resultado = "COMPRA NO INICIADA";
            if (carrito != null)
            {
                Producto producto = buscarProducto(nombre);
                if (producto != null)
                {
                    if (producto.getCantidad() >= cantidad)
                    {
                        carrito.agregarProducto(producto.getId(), producto.getNombre(), producto.getPrecioUnitario(), cantidad);
                        producto.setCantidad(producto.getCantidad() - cantidad);
                       resultado = "AGREGAR_OK";
                    }
                    else
                    {
                        resultado = "NO_HAY_STOCK";
                    }
                }
                else
                {
                    resultado = "PRODUCTO_INVALIDO";
                }
            }
            return resultado;
        }

        public bool finalizarCompra()
        {
            bool pudoFinalizar = false;
            if (carrito != null)
            {
                Console.WriteLine(carrito);
                carrito = null;
                pudoFinalizar = true;
            }
            return pudoFinalizar;
        }

        public bool descartarCompra()
        {
            bool pudoDescartar = false;
            if (carrito != null)
            {
                foreach (Producto item in carrito.getItems())
                {
                    this.buscarProducto(item.getNombre()).sumarStock(item.getCantidad());
                }
                carrito = null;
                pudoDescartar = true;
            }
            return pudoDescartar;
        }


    }
}
