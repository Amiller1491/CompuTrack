   M S B A M L   `   `   `  ����H  DCompuTrackWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CompuTrackWPFCompuTrackWPF  5   	   k gTelerik.Windows.Controls.Input, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�\clr-namespace:Telerik.Windows.Controls.MaskedTextBox;assembly=Telerik.Windows.Controls.Input&Telerik.Windows.Controls.MaskedTextBox 5   �   e aTelerik.Windows.Controls, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7uPclr-namespace:Telerik.Windows.Controls.Chromes;assembly=Telerik.Windows.Controls Telerik.Windows.Controls.Chromes 6  (    "CompuTrackWPF.InternalTicketWindow   5   	   %localclr-namespace:CompuTrackWPF  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Atelerik1http://schemas.telerik.com/2008/xaml/presentation   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6H   �&Telerik_Windows_Controls_MaskedTextBox\clr-namespace:Telerik.Windows.Controls.MaskedTextBox;assembly=Telerik.Windows.Controls.Input   6�   y Telerik_Windows_Controls_ChromesPclr-namespace:Telerik.Windows.Controls.Chromes;assembly=Telerik.Windows.Controls   6    � Title$  InternalTicketWindow��5   	   $	��400��6&   $	��501��63   ���	#FFFFE773 � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6   
���   � � WindowStartupLocation$ CenterOwner=�5	   	    � ShowInTaskbar .  $��1q�6C    � 	Resources 5
      *  $CompuTrackWPF.TicketStatusCollection   
StatusList3  -CompuTrackWPF.InternalTicketCommLogCollection  CommLogList1  +CompuTrackWPF.InternalTicketNotesCollection  	NotesList��%W   &	        &	      &	 &       5   
   6'     5   
   60     5   
   6.   5      .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5   
   �� $��10,0,8,0q�6   .+�5      (  "Telerik.Windows.Controls.RadButton  -   5          Name$ SaveBtn��5      $
��Save��6.   $��22.61��6=   $��12��6L    �� Left$ 305.705��6Z   
	 �� Top$	 362.39��6p   $��80.144��6�   6�     5      -   5        $ 	CancelBtn��5      $��Cancel��60   $��22.61��6A   $��80.144��6h   $��13��6w   
 J� RenderTransformOrigin$
 0.576,0.469&�6�   $ 389.849��6�   $	 362.39��6�   �� 5      -   5         ��Name$ basicHardwareGbx��5      $��Hardware Diagnostics��6.   $��132.144��6L   $��226.306��6]   $ 8��6m   $	 61.689��6}   .��5      �� $��0,2,0,-2q�6   .+�5      �� -   5         ��Name$ hardDriveLbl��5      $��
Hard Drive��6)   $��74.249��6>   $	 1��6M   $ 2��6\   �� 5      -   5        $ 	MemoryLbl��5      $��Memory��6&   $��60.585��67   $ 2��6F   $	 29.945��6V   �� 5      -   5         ��Name$ badHardwareTextBox��5       �� TextWrapping$
 Wrap=�61   $ 4��6E   $	 81.224��6U   $��202.306��6i   $��6��6y    �� 	MaxLength$ 50��6�   �� 5      $$��Other malfunctioning hardware:��6   $	 56.264��6<   	� 5      -   5         	�Name$ hddPassRadio��5      $
��Pass��6/   $ 71.249��6>   $	 6��6S   $��2��6b    	� 	GroupName$ 	HardDrive��6o   	� 5      -	   5        $ hddFailRadio��5      $
��Fail��6/   $ 121.249��6>   $	 6��6T   $��2��6c   $ 	HardDrive��6p   	� 5      -
   5        $ memoryPassRadio��5      $
��Pass��62   $ 71.249��6A   $	 36��6V   $��2��6f   $ Memory��6s   	� 5      -   5        $ memoryFailRadio��5      $
��Fail��62   $ 121.249��6A   $	 36��6W   $��2��6g   $ Memory��6t   5      5      �� 5      -   5        $ workDoneTxBx��5      $
 
1.25,0.339&�6)   $
 Wrap=�6L   $��7��6`   $��225.307��6m   $��116.808��6}   $ 8.999��6�   $	 222.72��6�   $	 500��6�   �� 5       -   5        $ workDoneLbl��5       $��Work Summary��6&   $ 7.999��6=   $	 195.76��6Q   �� 5!      $��
Ticket No:��6   $��26.728��6&   $��61.627��66   $��Right=�6E   $
 0.944,0.561&�6h   $ 367.113��6�   $	 -0.768��6�   �� 5"      -   5        $ ticketNoLbl��5"      $	��N/A��6&   $��51.921��64   $��Right=�6C   $
 0.172,0.499&�6f   $ 414.856��6�   �� 5#      -   5        $ NoteTxBx��5#      $
 
1.25,0.339&�6%   $
 Wrap=�6H   $��9��6\   $��100.401��6i   $ 264.556��6z   $	 93.432��6�   $��202.307��6�   $	 350��6�   �� 5$      -   5        $ CommLogTxBx��5$      $
 
1.25,0.339&�6(   $
 Wrap=�6K   $��11��6_   $��91.808��6m   $ 264.556��6}   $	 247.72��6�   $��202.307��6�   $	 350��6�   �� 5%      -   5        $ NoteLbl��5%      $��Notes��6"   $ 264.556��62   $	 39.472��6H   �� 5&      -   5        $ 
commLogLbl��5&      $��Communication Log��6%   $
 5.216,1.796&�6A   $
��Left=�6e   $ 264.556��6�   $	 195.76��6�     5'      -   5        $ saveNoteBtn��5'      $
��Save��62   $��41.093��6A   $��17��6P   $��22.61��6^   $ 425.77��6m   $	 44.822��6�   $y�Hidden=�6�   6�     5(      -   5        $ 
saveLogBtn��5(      $
��Save��61   $��41.007��6@   $��17��6O   $��22.61��6]   $ 425.77��6l   $	 197.833��6�   $y�Hidden=�6�   6�   *  $Telerik.Windows.Controls.RadComboBox  5)      -   5          Name$ statusComboBox��5)       �� DisplayMemberPath$ statusString��6r      
IsReadOnly . $��225.307��6�   $ 8.999��6�   $	 37.689��6�   $��1��6  ��67   ��  �� Source# [  6    5*      -   5        $ NotesComboBox��5*      $ visibleString��6p    .    	EmptyText$ Select a note...��6�   $ 264.556��6�   $	 69.432��6�   $��202.307��6�   $��8��6�   ��66   �� # [ 6    5+      -   5        $ LogComboBox��5+      $ visibleString��6p    . $ Select an entry...��6�   $ 264.556��6�   $	 221.72��6�   $��202.307��6�   $��10��6�   ��64   �� # [ 6  �� 5,      -   5        $ 
lblMessage��5,      $�� ��6%   $��273.48��60   $ 12.173��6?   $	 344.04��6T   �� 5-      -   5        $ 
titleLabel��5-      $��Internal Ticket��6%   $
��Bold"�6?   $��21.333(�6Q   $ 8.999��6c   5.      5/      50      