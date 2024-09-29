/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.ejercicio2di.informe;

import java.util.ArrayList;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 17 sept 2024
 */
public class InformeMainJava {
  public static void main (String[] args) {
    ArrayList<Informe> listaInformes = new ArrayList<Informe>();

    // agregar 10 informes & mostrar contenido
    generarInformes(listaInformes, 10);
    mostrarContenidoInformes(listaInformes);
    borrarContenidoLista(listaInformes);
  }
  
  public static void generarInformes (ArrayList<Informe> listaInformesTemp, int sizeLista) {
    for (int i = 0; i < sizeLista; i++) {
      int codigoNumerico = generarEnteroRandom(1, 100);
      int indiceTarea = generarEnteroRandom(0, 2);
      
      Informe informeTemp = new Informe(codigoNumerico, indiceTarea);
      listaInformesTemp.add(informeTemp);
    }
  }
  
  public static int generarEnteroRandom (int minimo, int maximo){
    return (int) (Math.random() * (maximo - minimo + 1)) + minimo;
  }
  
  public static void mostrarContenidoInformes (ArrayList<Informe> listaInformesTemp) {
    for (int i = 0; i < listaInformesTemp.size(); i++) {
      Informe informeTemp = listaInformesTemp.get(i);
      
      String nombreInforme = "informe-" + (i+1);
      int codigoInforme = informeTemp.getCodigo();
      String tareaInforme = informeTemp.getTarea();
      
      System.out.println(nombreInforme + " | " + codigoInforme + " | " + tareaInforme + " |");
    }
  }
  
  public static void borrarContenidoLista (ArrayList<Informe> listaInformesTemp) {
    listaInformesTemp.clear();
  }
}
