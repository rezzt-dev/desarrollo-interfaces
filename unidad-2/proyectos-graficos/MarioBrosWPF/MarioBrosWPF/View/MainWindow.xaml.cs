using MarioBrosWPF.domain;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MarioBrosWPF
{
  public partial class MainWindow : Window
  {
    private Random rnd = new Random(DateTime.Now.Millisecond);
    private Player mario = new Player("mario");
    private Image doorImage;
    private Image marioImage;
    private int[,] board = new int[8, 8];
    private int minPotion;

    public MainWindow()
    {
      InitializeComponent();
      inicializar();
      this.KeyDown += MainWindow_KeyDown;
    }

    // Private Helper Methods
    private void ClearCell(int row, int col)
    {
      var elementsToRemove = container.Children
          .Cast<UIElement>()
          .Where(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col && e != marioImage)
          .ToList();

      foreach (var element in elementsToRemove)
      {
        container.Children.Remove(element);
      }
    }

    private void RemoveImageAt(int row, int col)
    {
      var imageToRemove = container.Children.Cast<UIElement>()
          .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == col && e != marioImage) as Image;
      if (imageToRemove != null)
      {
        container.Children.Remove(imageToRemove);
      }
    }

    private void UpdatePlayerUI()
    {
      if (txtLifes != null)
      {
        txtLifes.Text = mario.lifes.ToString();
        txtLifes.TextAlignment = TextAlignment.Center;
      }
      if (txtPotion != null)
      {
        txtPotion.Text = minPotion.ToString();
        txtPotion.TextAlignment = TextAlignment.Center;
      }
      if (txtPlayerLifes != null)
      {
        txtPlayerLifes.Text = mario.lifes.ToString();
      }
      if (txtMinPotion != null)
      {
        txtMinPotion.Text = minPotion.ToString();
      }
      if (txtPlayerPotion != null)
      {
        txtPlayerPotion.Text = mario.potions.ToString();
      }
      if (slideCantVidas != null)
      {
        slideCantVidas.Value = mario.lifes;
      }
      if (slidePocimaTotal != null)
      {
        slidePocimaTotal.Value = minPotion;
      }
    }

    // Private Game Logic Methods
    private void inicializar()
    {
      fillWithImages(board, mario);

      // Crear y posicionar la imagen de Mario
      slideCantVidas.Value = mario.lifes;
      slidePocimaTotal.Value = minPotion;
      minPotion = 5;
      ClearCell(mario.posI, mario.posJ);
      marioImage = new Image();
      marioImage.Source = new BitmapImage(new Uri("/Images/mario.png", UriKind.Relative));
      Panel.SetZIndex(marioImage, 100);
      Grid.SetRow(marioImage, mario.posI);
      Grid.SetColumn(marioImage, mario.posJ);
      container.Children.Add(marioImage);

      // Actualizar la UI con los datos del jugador
      UpdatePlayerUI();
    }

    private void MainWindow_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.W: MoveMario(-1, 0); break;
        case Key.S: MoveMario(1, 0); break;
        case Key.A: MoveMario(0, -1); break;
        case Key.D: MoveMario(0, 1); break;
      }
    }

    private void MoveMario(int rowChange, int colChange)
    {
      int newRow = mario.posI + rowChange;
      int newCol = mario.posJ + colChange;

      if (newRow >= 0 && newRow < 8 && newCol >= 0 && newCol < 8)
      {
        mario.posI = newRow;
        mario.posJ = newCol;
        Grid.SetRow(marioImage, mario.posI);
        Grid.SetColumn(marioImage, mario.posJ);

        CheckBoardInteraction();

        if (doorImage != null && mario.posI == board.GetLength(0) - 1 && mario.posJ == board.GetLength(1) - 1)
        {
          EndGame(true);
        }
      }
    }

    private void CheckBoardInteraction()
    {
      switch (board[mario.posI, mario.posJ])
      {
        case 0: // Clavo
          mario.lifes--;
          board[mario.posI, mario.posJ] = -1;
          RemoveImageAt(mario.posI, mario.posJ);
          break;
        case 1: // Estrella (ahora da una vida)
          mario.lifes++;
          board[mario.posI, mario.posJ] = -1;
          RemoveImageAt(mario.posI, mario.posJ);
          break;
        case 2: // Poción (nueva)
          mario.potions++;
          board[mario.posI, mario.posJ] = -1;
          RemoveImageAt(mario.posI, mario.posJ);
          break;
      }

      UpdatePlayerUI();

      if (mario.potions >= minPotion)
      {
        GenerateDoor();
      }

      if (mario.lifes <= 0)
      {
        EndGame(false);
      }
    }

    private void GenerateDoor()
    {
      if (doorImage == null)
      {
        int lastRow = board.GetLength(0) - 1;
        int lastCol = board.GetLength(1) - 1;
        ClearCell(lastRow, lastCol);

        doorImage = new Image();
        doorImage.Source = new BitmapImage(new Uri("/Images/door-open.png", UriKind.Relative));
        Panel.SetZIndex(doorImage, 99);
        Grid.SetRow(doorImage, lastRow);
        Grid.SetColumn(doorImage, lastCol);
        container.Children.Add(doorImage);

        board[lastRow, lastCol] = 3;
      }
    }

    private void EndGame(bool won)
    {
      string message = won ? "¡Felicidades! Has ganado el juego." : "Game Over!";
      MessageBoxResult result = MessageBox.Show(message + "\n¿Quieres jugar de nuevo?", "Fin del juego", MessageBoxButton.YesNo);

      if (result == MessageBoxResult.Yes)
      {
        RestartGame();
      }
      else
      {
        this.Close(); // Cierra la aplicación si el usuario no quiere jugar de nuevo
      }
    }

    private void RestartGame()
    {
      // Limpiar el tablero
      container.Children.Clear();
      board = new int[8, 8];

      // Reiniciar el jugador
      mario = new Player("Mario");

      // Reiniciar variables de juego
      doorImage = null;
      marioImage = null;
      slideCantVidas.Value = mario.lifes;
      slidePocimaTotal.Value = minPotion;

      // Volver a inicializar el juego
      inicializar();

      // Actualizar la UI
      UpdatePlayerUI();
    }

    private void txtLifes_TextChanged(object sender, TextChangedEventArgs e)
    {
      if (int.TryParse(txtLifes.Text, out int newLifes))
      {
        mario.lifes = newLifes;
        UpdatePlayerUI();
      }
      else
      {
        // Si el texto no es un número válido, revertimos al valor actual de vidas
        txtLifes.Text = mario.lifes.ToString();
      }
    }

    // Public Methods
    public int generateRandom()
    {
      return rnd.Next(0, 4); // Ahora incluye 0, 1, 2, 3
    }

    public void fillWithImages(int[,] board, Player player)
    {
      player.posI = 0;
      player.posJ = 0;

      int maxRow = board.GetLength(0) - 1;
      int maxCol = board.GetLength(1) - 1;

      for (int i = 0; i < board.GetLength(0); i++)
      {
        for (int j = 0; j < board.GetLength(1); j++)
        {
          int randomValue = generateRandom();
          board[i, j] = randomValue;

          ClearCell(i, j);

          if (i == maxRow && j == maxCol)
          {
            board[i, j] = 3;
            Image doorImg = new Image();
            doorImg.Source = new BitmapImage(new Uri("/Images/door-close.png", UriKind.Relative));
            Panel.SetZIndex(doorImg, 99);
            Grid.SetColumn(doorImg, j);
            Grid.SetRow(doorImg, i);
            container.Children.Add(doorImg);
          }
          else if (randomValue != 3) // 3 ahora representa espacio vacío
          {
            Image img = new Image();
            string imagePath = randomValue == 0 ? "/Images/nail.png" :
                               randomValue == 1 ? "/Images/star.png" :
                               "/Images/potion.png"; // Nueva imagen para la poción
            img.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            Grid.SetColumn(img, j);
            Grid.SetRow(img, i);
            container.Children.Add(img);
          }
        }
      }
    }

    private void txtPlayerLifes_TextChanged(object sender, TextChangedEventArgs e)
    {
      txtPlayerLifes.Text = mario.lifes.ToString();
    }

    private void txtMinPotion_TextChanged(object sender, TextChangedEventArgs e)
    {
      txtPlayerLifes.Text = minPotion.ToString();
    }

    private void txtPlayerPotion_TextChanged(object sender, TextChangedEventArgs e)
    {
      txtPlayerLifes.Text = mario.potions.ToString();
    }

    private void slideCantVidas_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (mario != null && txtLifes != null)
      {
        mario.lifes = (int)slideCantVidas.Value;
        txtLifes.Text = mario.lifes.ToString();
        UpdatePlayerUI();
      }
    }

    private void slidePocimaTotal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
      if (txtPotion != null)
      {
        minPotion = (int)slidePocimaTotal.Value;
        txtPotion.Text = minPotion.ToString();
        UpdatePlayerUI();
      }
    }
  }
}
