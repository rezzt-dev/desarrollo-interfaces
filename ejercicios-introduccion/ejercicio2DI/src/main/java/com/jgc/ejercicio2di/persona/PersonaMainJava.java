/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.ejercicio2di.persona;

import java.util.ArrayList;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 17 sept 2024
 */
public class PersonaMainJava {
  public static void main (String[] args) {
    ArrayList<Persona> listaPersonas = new ArrayList<Persona>();
    int numeroPersonasCola = generarEnteroRandom(0, 50);
    generarCola(listaPersonas, numeroPersonasCola);
    
    float recaudacion = 0;
    
    for (int i = listaPersonas.size() - 1; i >= 0; i--) {
      Persona tempPersona = listaPersonas.get(i);
      int edadTempPersona = tempPersona.getEdad();
      
      listaPersonas.remove(i);
      
      if ((edadTempPersona >= 5) && (edadTempPersona <= 10)) {
        recaudacion += 1.0;
      } else if ((edadTempPersona >= 11) && (edadTempPersona <= 17)) {
        recaudacion += 2.5;
      } else {
        recaudacion += 3.5;
      }
    }
    
    // System.out.println(listaPersonas);
    System.out.println(recaudacion);
  }
  
  public static void generarCola (ArrayList<Persona> listaAyuda, int numPersonas) {
    for (int i = 0; i < numPersonas; i++) {
      int edadRandom = generarEnteroRandom(5, 60);
      
      Persona personaTemp = new Persona(edadRandom);
      listaAyuda.add(personaTemp);
    }
  }
  
  public static int generarEnteroRandom(int minimo, int maximo){
    int num=(int)Math.floor(Math.random()*(minimo-
    (maximo+1))+(maximo+1));
    return num;
  }
}
