   M S B A M L   `   `   `  ���� M  ISpartaGlobalAppGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SpartaGlobalAppGUISpartaGlobalAppGUI  #    SpartaGlobalAppGUI.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:SpartaGlobalAppGUI     b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
MainWindow��$	��450��$	��800��.��� -   $��MainGrid��$
��Left=�$	��800�� � ColumnDefinitions �� $	��90* ��� $	��20* ��� $	��90* �.+�� -   $��	LoginGrid��$��0�� � RowDefinitions �� $	��76* ��� $	��45* ��� $	��14* ��� $	��40* ��� $	��14* ��� $	��40* ��� $	��18* ��� $	��26* ��� $	��19* ��� $	��39* ��� $	��39* ��� $	��63* � �� $��8* ��� $��9* ��� $	��66* ��� $��7* �.+��� $��2��$��Center=�$��1��$��Welcome!��$
��Bold"�$��28(�$��Center=�$��37��$	��132��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$	 Key=�$��Center=����#707070$��1��$��5��$��Center=�$��16��$��16��  $ Account=�$��Center=����#707070$��1��$��3��$��Center=�$��16��$��16���� -    ��Name$ loginUsername��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��$��2��$��3��$��5,5,5,5q� �� MaxLines$ 1�� �� 	MaxLength$ 30���� -   $ loginPassword��$ Password��$��2��$��5��$��5,5,5,5q�$ 1��$ 30���� -   $��
RememberMe��$��Remember Me��$��5,0,5,0q�$��Center=�$��2��$��7�����#707070$��15���� -   $��Login��$��2��$��5,5,5,5q�$��9�����	#FFABADB3
����������#707070$
��Bold"��� -   $��Register��$��2��$��5q�$��10�����	#FFABADB3
����������#707070$
��Bold"�� -   $��RegisterGrid��$��2�� �� $	��26* ��� $	��57* ��� $	��34* ��� $	��34* ��� $	��34* ��� $	��34* ��� $	��34* ��� $	��40* ��� $	��39* ��� $	��39* ��� $	��61* � �� $	��15* ��� $	��60* ��� $	��82* ��� $	��23* �.+��� $��1��$��2��$��Center=�$��1��$��Sign Up��$
��Bold"�$��28(�$��Center=�$��37��$	��132���� -	   $ registerName��$
 Name��$��2��$��2��$��5,5,5,5q�$ 1��$ 30���� -
   $ registerUsername��$ Username��$��2��$��3��$��5,5,5,5q�$ 1��$ 30���� -   $ registerPassword��$ Password��$��2��$��4��$��5,5,5,5q�$ 1��$ 30���� -   $ registerCPassword��$ Confirm Password��$��2��$��5��$��5,5,5,5q�$ 1��$ 30���� -   $ registerCourse��$ Course��$��2��$��6��$��5,5,5,5q�$ 1��$ 30���� -   $ registerTrainer��$ Course��$��2��$��7��$��5,5,5,5q�$ 1��$ 30���� -    ��Name$ 
trainerBox��$��I am a Trainee��$��5,0,5,0q�$��Center=�$��2��$��10�����#707070$��15���� -   $��Register��$��1��$��2��$��5,5,5,5q�$��8�����	#FFABADB3
����������#707070$
��Bold"��� -   $��Login��$��1��$��2��$��5,5,5,5q�$��9�����	#FFABADB3
����������#707070$
��Bold"��� $��1��$��2��$��Name:��$
��Left=�$��Center=�$��14(�$��22��$��39���� $��1��$��3��$��	Username:��$
��Left=�$��Center=�$��14(�$��21��$��64���� $��1��$��4��$��	Password:��$
��Left=�$��Center=�$��14(�$��21��$��61���� $��1��$��5��$��Confirm Password:��$
��Left=�$��Center=�$��14(�$��21��$	��116���� $��1��$��6��$��Course:��$
��Left=�$��Center=�$��14(�$��21��$��46���� $��1��$��7��$��Trainer:��$
��Left=�$��Center=�$��14(�$��21��$��46��� -   $��	SlideGrid��$��1��$��2��	 J� RenderTransformOrigin$	 0.5,0.5&�z�V� .~��� �� �� T� 
 T� X$

 -360Q�.+��� 
�������$	 0.5,0.5&�z�V� .~��� �� �� T� -   slideCanvas��$	
 360Q� T� Y$ 0Q�.+��� $��/spartalogo4.png�� �� StretchDirection$
 Both=� K� ZIndex$ 1��$	��434��$	��440���� $	��434��$	��440��$ 0������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#CC3F1B7E�� � Offset$ 1Q�� $ 	#CCEC2323��� $ 	#CCCBB0F5��$ 0.566Q�