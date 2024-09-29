/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.proyectonodos;

import java.util.Stack;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 12 sept 2024
 */
public class Ejercicio1DI {
  public static void main(String[] args) {
    System.out.println(" > mi pila dinamica");
    
    PilaDinamica<Integer> pilaNumeros = new PilaDinamica<>();
    System.out.println(" la pila esta vacia? (inicio) " + pilaNumeros.isEmpty());
    
    pilaNumeros.push(5);
    pilaNumeros.push(10);
    pilaNumeros.push(15);
    pilaNumeros.push(20);

    System.out.println(" la pila esta vacia? (despues de agregar) " + pilaNumeros.isEmpty());
    System.out.println(" el tamaño ahora es de " + pilaNumeros.size());
    System.out.println(" el top es " + pilaNumeros.top());
    
    int elemento = pilaNumeros.pop();
    
    System.out.println(" he sacado el numero " + elemento);
    System.out.println(" el tamaño ahora es de " + pilaNumeros.size());
    
    System.out.println(" el top es " + pilaNumeros.top());
    System.out.println(pilaNumeros);
    
   //-----------------------------------------------------------------------------------------|
    System.out.println("\n Stack de Java");
    
    Stack<Integer> pilaStack = new Stack<>();
    System.out.println(" la pila esta vacia? (inicio) " + pilaStack.isEmpty());
    
    pilaStack.push(5);
    pilaStack.push(10);
    pilaStack.push(15);
    pilaStack.push(20);
    
    System.out.println(" la pila esta vacia? (despues de agregar) " + pilaStack.isEmpty());
    System.out.println(" el tamaño es de " + pilaStack.size());
    
    System.out.println(" el top es " + pilaStack.peek());
    
    int elemento2 = pilaStack.pop();
    
    System.out.println(" he sacado el numero " + elemento2);
    System.out.println(" el tamaño ahora es de " + pilaStack.size());
    
    System.out.println(" el top es " + pilaStack.peek());
    System.out.println(pilaStack);
  }
}
