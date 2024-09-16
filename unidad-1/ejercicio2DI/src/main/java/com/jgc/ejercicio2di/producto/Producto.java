/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.ejercicio2di.producto;

import java.text.DecimalFormat;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 16 sept 2024
 */
public class Producto {
  private int cantidad;
  private double precio;
  
  /**
  * Constructor por defecto
  * @param cantidad
  * @param precio
  */
  public Producto(int cantidad, double precio){
    this.cantidad=cantidad;
    this.precio=precio;
  }
  
  /**
  * Devuelve la cantidad de productos
  * @return Cantidad de producto
  */
  public int getCantidad() {
    return cantidad;
  }
  
  /**
  * Devuelve el precio
  * @return Precio del producto
  */
  public double getPrecio() {
    return precio;
  }
  
  /**
  * Devuelve el precio final que tiene un producto
  * @return precio final
  */
  public double precioFinal(){
    //Formateamos el precio final por problemas de precision
    DecimalFormat df=new DecimalFormat("#,##");
    return Double.parseDouble(df.format(this.precio * this.cantidad));
  }
}
