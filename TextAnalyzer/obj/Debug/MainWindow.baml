   M S B A M L   `   `   `  ����G  CTextAnalyzer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TextAnalyzerTextAnalyzer  5   	       TextAnalyzer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TextAnalyzer     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��391* �6   �� 5      $��6* �6    � RowDefinitions 5   
   �� 5      $
��192* �6   �� 5      $
��229* �6   .+�5   
   �� -   5        $��Открыть файл��5      $
��Left=�6(   $��25��6C   $��
580,17,0,0q�6O   $	��Top=�6c   $	��191��6{   6�   �� 5   
   -   5        $!��Сохранить файл��5      $
��Left=�6*   $��25��6E   $��
580,58,0,0q�6Q   $	��Top=�6e   $	��191��6}   6�   �� 5   
   -   5         ��Name$ Field��5      $
��Left=�6!   $	��385��6<   $��	19,17,0,0q�6I   $��2��6\    �� TextWrapping$
 Wrap=�6m   $�� ��6�   $	��Top=�6�   $	��543��6�   �� 5   
   -   5        $)��#Вывести информацию��5      $
��Left=�6.   $��25��6I   $��
580,98,0,0q�6U   $	��Top=�6i   $	��191��6�   6�   5      5      