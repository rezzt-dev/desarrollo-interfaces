/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.ejercicio2di.persona;

import com.jgc.ejercicio2di.ListaEnlazada;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 16 sept 2024
 */
public class PersonaMain {
  public static void main (String[] args) {
    ListaEnlazada<Persona> listaPersonas = new ListaEnlazada<Persona>();
    int numeroPersonasCola = generarEnteroRandom(0, 50);
    generarCola(listaPersonas, numeroPersonasCola);
    
    float recaudacion = 0;
    
    for (int i = 0; i < listaPersonas.cuantosElementos(); i++) {
      Persona tempPersona = (Persona) listaPersonas.devolverDato(i);
      int edadTempPersona = tempPersona.getEdad();
      
      listaPersonas.borraPosicion(i);
      
      if ((edadTempPersona >= 5) && (edadTempPersona <= 10)) {
        recaudacion += 1.0;
      } else if ((edadTempPersona >= 11) && (edadTempPersona <= 17)) {
        recaudacion += 2.5;
      } else {
        recaudacion += 3.5;
      }
    }
    
    // listaPersonas.mostrar();
    System.out.println(recaudacion);
  }
  
  public static void generarCola (ListaEnlazada<Persona> listaAyuda, int numPersonas) {
    for (int i = 0; i < numPersonas; i++) {
      int edadRandom = generarEnteroRandom(5, 60);
      
      Persona personaTemp = new Persona(edadRandom);
      listaAyuda.introducirDato(i, personaTemp);
    }
  }
  
  public static int generarEnteroRandom(int minimo, int maximo){
    int num=(int)Math.floor(Math.random()*(minimo-
    (maximo+1))+(maximo+1));
    return num;
  }
}
