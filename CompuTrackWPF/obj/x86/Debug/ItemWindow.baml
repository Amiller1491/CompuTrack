   M S B A M L   `   `   `  ����H  DCompuTrackWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CompuTrackWPFCompuTrackWPF  5   	       CompuTrackWPF.ItemWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   k gTelerik.Windows.Controls.Input, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Atelerik1http://schemas.telerik.com/2008/xaml/presentation   5      <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6F   %cclr-namespace:CompuTrackWPF   5   	   -   5          �Name$  
itemWindow��5   �    � Title$ 
ItemWindow��6	   $	��280��6   $	��450��6)   ���	#FFFFE773 � WindowStyle$
 None=�6j    � 
ResizeMode$ NoResize=�6}   
���   � � WindowStartupLocation$ CenterOwner=�5   	    � ShowInTaskbar .  $��1q�6C    � 	Resources 5	      $  CompuTrackWPF.ItemCategoryData   CategoryList��%   &	          5
   
   6   5      .��5      � .+�5   
   �� -   5         ��Name$ 	itemLabel��5   ]   $��Category��6   $��30��6#   $
��Left=�6/   $��	13,36,0,0q�6J   $	��Top=�6p   $��69��6�   $
��Bold"�6�   �� 5   
   -   5        $ 	makeLabel��5   Y   $
��Make��6   $��30��6   $
��Left=�6+   $��	13,69,0,0q�6F   $	��Top=�6l   $��69��6�   $
��Bold"�6�   �� 5   
   -   5        $ 
modelLabel��5   [   $��Model��6   $��30��6    $
��Left=�6,   $��
13,100,0,0q�6G   $	��Top=�6o   $��69��6�   $��Normal"�6�   �� 5   
   -   5        $ 
specsLabel��5   [   $��Specs��6   $��30��6    $
��Left=�6,   $��
13,134,0,0q�6G   $	��Top=�6o   $��69��6�   �� 5   
   -   5        $ quantityLabel��5   ^   $��Quantity��6   $��30��6#   $
��Left=�6/   $��
13,165,0,0q�6J   $	��Top=�6u   $��69��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ itemMakeBox��5   l   $��23��61   $
��Left=�6=   $��
86,0,0,186q�6X   $��2��6�   $��Bottom=�6�   $	��120��6�   	 �� 	MaxLength$	 25��6�   
���   �6�   �� 5   
   -   5        $ itemModelBox��5   l   $��23��61   $
��Left=�6=   $��
86,100,0,0q�6X   $��3��6�   $	��Top=�6�   $	��120��6�   $	 25��6�   
���   �6�   �� 5   
   -	   5        $ itemSpecsBox��5   �   $��23��61   $
��Left=�6=   $��
86,136,0,0q�6X   $��4��6l   $	��Top=�6y   $	��120��6�   $	 25��6�   
���   �6�   !  CompuTrackWPF.NumberTextBox  5   
   -
   5        
  Name$
 quantityBox��5   s   !   CompuTrackWPF.NumberTextBox   KeyDown$ newItemField_KeyDown��6   $��23��69   $
��Left=�6E   $��	86,0,0,87q�6`   $��5��6�   $��Bottom=�6�   $	��120��6�   $	 3��6�   
���   �6�   (  "Telerik.Windows.Controls.RadButton  5   
   -   5          Name$ saveItemBtn��5   g   $
��Save��6   $��23��6+   $
��Left=�67   $��137,245,0,0q�6R   $��7��6|   $	��Top=�6�   $��75��6�   6�     5   
   -   5        $ cancelItemBtn��5   N   $��Cancel��6   $��23��6-   $��0,245,146,0q�69   $��8��6e   $	��Top=�6r   $��Right=�6�   $��75��6�   �� 5   
   -   5        $ label8��5   l   $��(e.g. Western Digital)��6   $��30��61   $
��Left=�6=   $��
212,69,0,0q�6X   $	��Top=�6|   $	��124��6�   �� 5   
   -   5        $ label9��5   h   $��(e.g. WD500AAAKS)��6   $��30��6,   $
��Left=�68   $��212,100,0,0q�6S   $	��Top=�6x   $	��116��6�   �� 5   
   -   5        $ label11��5   c   $��(e.g. 500GB)��6   $��30��6'   $
��Left=�63   $��212,134,0,0q�6N   $	��Top=�6t   $	��100��6�   �� 5   
   -   5        $ messageLabel��5   "   $��0,0,0,34q�6    J� RenderTransformOrigin$ 
9.15,0.576&�68   $��Bottom=�6[   $��27��6v   $��Center=�6�   �� 5   
   -   5        $ thresholdLabel��5   _   $��	Threshold��6   $��30��6$   $
��Left=�60   $��
13,195,0,0q�6K   $	��Top=�6w   $��69��6�     5   
   -   5        $
 itemThresholdBox��5   s   $ newItemField_KeyDown��6   $��23��69   $
��Left=�6E   $��	86,0,0,57q�6`   $��6��6�   $��Bottom=�6�   $	��120��6�   $	 3��6�   
���   �6�   �� 5   
   -   5        $��itemCategoryBox��5   �    �� SelectedIndex$ 1��66   $��23��6H   $
��Left=�6T   $��	86,37,0,0q�6o   $	��Top=�6�   $	��138��6�    �� DisplayMemberPath$ CategoryString��6�   $��1��6Q  ��6�   ��  �� Source# [  6Q  �� 5   
   -   5        $��newCategoryBox��5   �   $��23��61   $��Right=�6=   $��	0,38,64,0q�6Y   $	 25��6l   $��8��6{   $	��Top=�6�   $	��120��6�   $�� ��6�   $y�Hidden=�6�   
���   �6�   �� 5    
   -   5        $ 
titleLabel��5       $��New Item��6$   $
��Left=�67   $	��Top=�6R   $��9,-4,0,0q�6j   $
��Bold"�6|   $��21.333(�6�   5!      5"      