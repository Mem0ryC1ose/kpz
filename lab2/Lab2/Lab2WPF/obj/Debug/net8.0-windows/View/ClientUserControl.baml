   M S B A M L   `   `   `  ����B  >Lab2WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Lab2WPF.ViewLab2WPF.View  5      $    Lab2WPF.View.ClientUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Lab2WPF.View     5      .��5	      � 
�������$��10q�6"     � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ SubjectsDataGrid��5         AutoGenerateColumns$
 True��5         CanUserAddRows$ False��5         CanUserReorderColumns$ False��5      ���#F0F0F0   GridLinesVisibility$ Vertical=�5      ���#D0D0D0$��1q�5         RowBackground �#E0E0E0   AlternatingRowBackground �#F9F9F9
���   �$��Stretch=�5      $��Stretch=�5      $��5q�5         ColumnHeaderHeight$ 30Q�5      ��5      �� *	Clients+5      �� 5    
   $��
Add Client��6   $��Right=�5"   
   $��Bottom=�5#   
   $	��100��5$   
   $��30��5%   
   ���#B0B0B0
���   ����#909090$��	5,5,10,10q�5)   
   ��5!   
   �� *AddClientCommand+5)   
   5*      5+      