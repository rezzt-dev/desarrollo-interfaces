/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.ejercicio2di.producto;

import java.util.ArrayList;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 17 sept 2024
 */
public class ProductoMainJava {
  public static void main(String[] args) {
    ArrayList<Producto> listaProductos = new ArrayList<Producto>();
    int sizeListaProductos = generarEnteroRandom(1, 8);
    generarListaProductos(listaProductos, sizeListaProductos);
    
    double precioTotal = 0;
    
    System.out.println("| Producto | Cantidad | Precio | Total |");
    
    for (int i = 0; i < listaProductos.size(); i++) {
      Producto productoTemp = listaProductos.get(i);
      
      int cantidadProductoTemp = productoTemp.getCantidad();
      double precioProductoTemp = productoTemp.getPrecio();
      
      double precioUnitarioProductoTemp = (cantidadProductoTemp * precioProductoTemp);
      precioTotal += precioUnitarioProductoTemp;
      
      System.out.println("| producto"+i + " | " + cantidadProductoTemp + " | " + precioProductoTemp + " | " + precioUnitarioProductoTemp + " |");
    }
    
    System.out.println("| Precio Final | | | " + precioTotal + " |");
    
  }
  
  public static void generarListaProductos (ArrayList<Producto> listaProductos, int sizeLista) {
    for (int i = 0; i < sizeLista; i++) {
      int cantidad = generarEnteroRandom(0, 10);
      double precio = generaNumeroRealAleatorio(1, 20);
      
      Producto productoTemp = new Producto(cantidad, precio);
      listaProductos.add(productoTemp);
    }
  }
          
  public static int generarEnteroRandom(int minimo, int maximo){
    int num=(int)Math.floor(Math.random()*(minimo-(maximo+1))+(maximo+1));
    return num;
  }
  
  public static double generaNumeroRealAleatorio(double minimo, double maximo){
    double num=Math.rint(Math.floor(Math.random()*(minimo-((maximo*100)+1))+((maximo*100)+1)))/100;
    return num;
  }
}
