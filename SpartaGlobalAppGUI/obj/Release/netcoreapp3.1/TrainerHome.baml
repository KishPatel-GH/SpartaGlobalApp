   M S B A M L   `   `   `  ���� M  ISpartaGlobalAppGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SpartaGlobalAppGUISpartaGlobalAppGUI  $    SpartaGlobalAppGUI.TrainerHome   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     2local clr-namespace:SpartaGlobalAppGUI       � Title$  TrainerHome��$	��450��$	��800��.���  � ColumnDefinitions �� $
��187* ��� $
��213* �.+�� $��0��$��Stretch=� � RowDefinitions �� $	��64* ��� $	��34* ��� $
��100* ��� $	��36* ��� $	��88* ��� $	��47* ��� $	��49* ��� $	��16* � �� $	��28* ��� $
��112* ��� $	��56* ��� $	��59* ��� $	��97* ��� $	��22* �.+��� -   $��5,5,5,5q�$��Create Question��$��1��$��5��$
��Bold"���Z� ����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	#FFDC6262��� $ 	#FFB78CD4�� � Offset$ 1Q�� $ 	#FFE0C2EC��$
 0.48Q��� -   $��QList��$��5,32,5,5q����	#FFE8E6E6$��1��$��2��$��1�����	#FFE8E6E6$��2���� -   $��TraineeList��$��5,32,5,5q����	#FFE8E6E6$��3��$��2��$��1�����	#FFE8E6E6$��2���� -   $��5,5,5,5q�$��Edit Question��$��2��$��5��$��2��$
��Bold"���Z� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFDC6262��� $ 	#FFB78CD4��$ 1Q�� $ 	#FFE0C2EC��$
 0.48Q��� -   $��5,5,5,5q�$��Pose Question��$��2��$��6��$��2��$
��Bold"���Z� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFDC6262��� $ 	#FFB78CD4��$ 1Q�� $ 	#FFE0C2EC��$
 0.48Q��� -   $��5,5,5,5q�$��Delete Question��$��1��$��6��$
��Bold"���Z� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFDC6262��� $ 	#FFB78CD4��$ 1Q�� $ 	#FFE0C2EC��$
 0.48Q��� -   $��5,5,5,5q�$��Clear��$��4��$��5��$
��Bold"���Z� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFDC6262��� $ 	#FFB78CD4��$ 1Q�� $ 	#FFE0C2EC��$
 0.48Q��� -    ��Name$ TraineeQuestionListbox��$��5,31,5,5q����	#FFE8E6E6$��1��$��4��$��3�����	#FFE8E6E6$��2���� -	   $��5,5,5,5q�$��Add Feedback��$��4��$��6��$
��Bold"���Z� ���� $ 0.5,1&�$ 0.5,0&�.��� $ 	#FFDC6262��� $ 	#FFB78CD4��$ 1Q�� $ 	#FFE0C2EC��$
 0.48Q��� $��5,5,5,0q�$��Question Bank��$��1��$��2��$��1�����	#FFCDCDCD���	#FFE8E6E6$
��Bold"��� $��5,5,5,0q�$��My Trainees��$��3��$��2��$��1�����	#FFCDCDCD���	#FFE8E6E6$
��Bold"��� $��5,5,5,0q�$��Posed Questions��$��1��$��4��$��3�����	#FFCDCDCD���	#FFE8E6E6$
��Bold"��� -
   $��UserWelcome��$��USER NAME - COURSE��$��2��$��Right=�$��Center=�$��4��$
��Bold"�$��16(��� -   $��SpartaButton��$��1��$��0����Z� ����  �� ImageSource$ /spartalogo.png��� $��1�� �� $	��20* ��� $	��34* ��� $	��34* ��� $	��31* ��� $	��25* ��� $	��36* ��� $
��105* ��� $	��35* ��� $	��94* ��� $	��20* � �� $	��20* ��� $
��116* ��� $
��129* ��� $
��145* ��� $	��16* �.+��� -   	 ��Name$	 SelectedQTB��$��5,32,5,5q�$��1��$��1��$��2��
 �� TextWrapping$

 Wrap=����	#FFE8E6E6���	#FFE8E6E6$��2���� -   $	 
CategoryTB��$��5,32,5,5q�$��1��$��3��$

 Wrap=����	#FFE8E6E6���	#FFE8E6E6$��Center=�$��Center=�$��2���� -    ��Name$ Response��$��5,34,5,5q�$��5��$��1��$��3��$
��Wrap=����	#FFE8E6E6$��2���� -   $	 Feedback��$��5,32,5,5q�$��7��$��1��$��3��$

 Wrap=����	#FFE8E6E6���	#FFE8E6E6$��2���� -   $	 StudentName��$��5,31,5,5q�$��3��$��1��$

 Wrap=����	#FFE8E6E6���	#FFE8E6E6$��Center=�$��Center=�$��2���� -   $	 	StudentID��$��5,31,5,5q�$��3��$��2��$

 Wrap=����	#FFE8E6E6���	#FFE8E6E6$��Center=�$��Center=�$��2���� -   $	 StudentCourse��$��5,31,5,5q�$��3��$��3��$

 Wrap=����	#FFE8E6E6���	#FFE8E6E6$��Center=�$��Center=�$��2���� $��5,5,5,0q�$��1��$��1��$��2��$��Question�����	#FFCDCDCD$
��Bold"�$��Center=�$��Center=��� $��5,5,5,0q�$��1��$��3��$��1��$��Category�����	#FFCDCDCD$
��Bold"�$��Center=�$��Center=��� $��5,5,5,0q�$��3��$��1��$��Student Name�����	#FFCDCDCD$
��Bold"�$��Center=�$��Center=��� $��5,5,5,0q�$��3��$��2��$��
Student ID�����	#FFCDCDCD$
��Bold"�$��Center=�$��Center=��� $��5,5,5,0q�$��3��$��3��$��Course�����	#FFCDCDCD$
��Bold"�$��Center=�$��Center=��� $��5,5,5,0q�$��5��$��1��$��3��$��Response�����	#FFCDCDCD$
��Bold"�$
��Left=�$��Center=��� $��5,5,5,0q�$��7��$��1��$��3��$��Feedback�����	#FFCDCDCD$
��Bold"�$
��Left=�$��Center=�