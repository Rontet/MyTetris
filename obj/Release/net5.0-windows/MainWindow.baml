   M S B A M L   `   `   `  ���� A  =Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:TetrisTetris      Tetris.MainWindow   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     &localclr-namespace:Tetris     -     � Title$  Tetris��$	��600��$	��800��$	��600��$	��600��
�������$��Segoe UI Light)�$��28(�.��� ����  �� ImageSource$ /Background.png�� � ColumnDefinitions �� $��* ��� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $��* �.+�(� $��1��$��1��$��0,0,0,20q�.���� -    ��Name$ 
GameCanvas��$	��480��$	��980��$
}�True�����	#FF202020�� -    ��Name$ 	ScoreText��$��Score: ��$
��Wrap=�$��0��$��1��$
��0,10q� �� TextAlignment$ Center=��� $��1��$��0��$	��Top=�$��Right=�.+��� $
��Hold��$ Center=��� -    ��Name$ 	HoldImage��$��20q�$	��125���� $��1��$��2��$	��Top=�$
��Left=�.+��� $
��Next��$ Center=�� 
������ $��Center=�$	��Top=� � 	Resources    NextImageTemplate��%L   &	        �� .R��� $
��20,0q�$	��125��$	��Top=�$��Center=����� .+�&   System.Windows.Controls.DataGrid  	   AutoGenerateColumns$	 False��
������ 
   RowBackground

 ���� ���	#00000000���	#00000000$��Center=�$	��Top=�   GridLinesVisibility$
 None=�${�False��$|�False�� J� IsHitTestVisible$ False�� � Cursor$
 None��   ColumnHeaderHeight$ 0Q�   RowHeaderWidth$ 0Q�����    Columns 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate# [  ,  &System.Windows.Controls.DataGridColumn   CanUserSort$ False��   CanUserResize$ False��   CanUserReorder$ False��� -    �Name$ GameOverMenu�����	#CC000000$��2��$��3��$y�Hidden=�.+��� $��Center=�$��Center=�.+��� $��	Game Over��$��48(�$ Center=��� -   $ FinalScoreText��$��Score: ��$��36(�$ Center=��� -   $��
Play Again��
������$��0,20,0,0q�$��5q�� -   $ 	PauseMenu�����	#CC000000$��2��$��3��$y�Hidden=�.+��� $��Center=�$��Center=�.+��� $��Pause��$��48(�$ Center=��� -	   $ PauseScoreText��$��Score: ��$��36(�$ Center=��� -
   $��Resume��
������$��0,20,0,0q�$��5q��� -   $��Restart��
������$��0,20,0,0q�$��5q�� -   $ StartupMenu�����	#CC000000$��2��$��3��$y�Visible=�.+��� $��Center=�$��Center=�.+��� $��Tetris��$��48(�$ Center=��� -   $
��Play��
������$��0,20,0,0q�$��5q�