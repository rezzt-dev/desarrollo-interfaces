/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.proyectonodos;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 12 sept 2024
 * @param <T>
 */

public class Nodo<T> {
  private T elemento;
  private Nodo<T> siguiente; //siguiente nodo
  
  public Nodo (T elemento, Nodo<T> siguiente) {
    this.elemento = elemento;
    this.siguiente = siguiente;
  }
  
  public T getElement () {
    return elemento;
  }
  
  public void setElemento (T elemento) {
    this.elemento = elemento;
  }
  
  public Nodo<T> getSiguiente () {
    return siguiente;
  }
  
  public void setSiguiente (Nodo<T> siguiente) {
    this.siguiente = siguiente;
  }
  
  @Override
  public String toString () {
    return elemento+"\n";
  }
}
