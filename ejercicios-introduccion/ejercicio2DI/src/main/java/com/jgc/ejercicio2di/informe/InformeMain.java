/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.jgc.ejercicio2di.informe;

import com.jgc.ejercicio2di.ListaEnlazada;

/**
 *
 * @author JGC by Juan Garcia Cazallas
 * @version 1.0
 * Created on 16 sept 2024
 */
public class InformeMain {
  public static void main (String[] args) {
    ListaEnlazada<Informe> listaInformes = new ListaEnlazada<Informe>();

     
     // agregar 10 informes & mostrar contenido
    generarInformes(listaInformes, 10);
    mostrarContenidoInformes(listaInformes);
    borrarContenidoLista(listaInformes);
  }
  
  public static void generarInformes (ListaEnlazada<Informe> listaInformesTemp, int sizeLista) {
    for (int i = 0; i < sizeLista; i++) {
      int codigoNumerico = generarEnteroRandom(1, 100);
      int indiceTarea = generarEnteroRandom(0, 2);
      
      Informe informeTemp = new Informe(codigoNumerico, indiceTarea);
      listaInformesTemp.introducirDato(i, informeTemp);
    }
  }
  
  public static int generarEnteroRandom (int minimo, int maximo){
    return (int) (Math.random() * (maximo - minimo + 1)) + minimo;
  }
  
  public static void mostrarContenidoInformes (ListaEnlazada<Informe> listaInformesTemp) {
    for (int i = 0; i < listaInformesTemp.cuantosElementos(); i++) {
      Informe informeTemp = listaInformesTemp.devolverDato(i);
      
      String nombreInforme = "informe-" + (i+1);
      int codigoInforme = informeTemp.getCodigo();
      String tareaInforme = informeTemp.getTarea();
      
      System.out.println(nombreInforme + " | " + codigoInforme + " | " + tareaInforme + " |");
    }
  }
  
  public static void borrarContenidoLista (ListaEnlazada<Informe> listaInformesTemp) {
    for (int i = 0; i < listaInformesTemp.cuantosElementos(); i++) {
      listaInformesTemp.borraPosicion(i);
    }
  }
}
