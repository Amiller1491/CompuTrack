   M S B A M L   `   `   `  ����H  DCompuTrackWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CompuTrackWPFCompuTrackWPF  5      k gTelerik.Windows.Controls.Input, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7�\clr-namespace:Telerik.Windows.Controls.MaskedTextBox;assembly=Telerik.Windows.Controls.Input&Telerik.Windows.Controls.MaskedTextBox 5   �   e aTelerik.Windows.Controls, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7uPclr-namespace:Telerik.Windows.Controls.Chromes;assembly=Telerik.Windows.Controls Telerik.Windows.Controls.Chromes 6       CompuTrackWPF.TicketWindow   5      $ctrlclr-namespace:CompuTrackWPF  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Atelerik1http://schemas.telerik.com/2008/xaml/presentation   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6D   �&Telerik_Windows_Controls_MaskedTextBox\clr-namespace:Telerik.Windows.Controls.MaskedTextBox;assembly=Telerik.Windows.Controls.Input   6�   y Telerik_Windows_Controls_ChromesPclr-namespace:Telerik.Windows.Controls.Chromes;assembly=Telerik.Windows.Controls   6  -   5          �Name$  Window��5       � Title$ TicketWindow��5	      $	��550��5
      $	��400��6   ���	#FFFFE773 � WindowStyle$
 None=�5       � 
ResizeMode$ NoResize=�6   
���   � � WindowStartupLocation$ CenterOwner=�5       � ShowInTaskbar .  $��1q�6?    � 	Resources 5          CompuTrackWPF.CustomerData   CustomerList��%   &	          5   
   6   5      .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5   
   *  $Telerik.Windows.Controls.RadComboBox  -   5          Name$ customerComboBox��5   b   $��22.61��6   $
��Left=�6-   $��79.95,35.496,0,0q�6H   	 �� DisplayMemberPath$	 FullNameString��6�   
 � OverridesDefaultStyle
 .     StaysOpenOnEdit .  $	��Top=�6;  $��192.344��6S     
IsEditable .    
IsReadOnly . !   CanAutocompleteSelectItems$
 TrueX�6�  %   ClearSelectionButtonVisibility$ Visible=�6�  "   ClearSelectionButtonContent$ Clear Selection��6     	EmptyText$! Please select a customer...��61  $��1��6�  ��6|   ��  �� Source# [  $ �� IsSynchronizedWithCurrentItem 6�   Z� 6�  �� 5   
   $��Customer��6   $��26.728��6#   $
��Left=�63   $��10.491,35.496,0,0q�6N   $	��Top=�6i   $��65.395��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ model��5   X   $��25.655��6   $
��Left=�6"   $��79.95,0,0,141.003q�6=    �� TextWrapping$
 Wrap=�6g   $��Bottom=�6{   $��134.853��6�   $��5��6�   �� 5   
   -   5         ��Name$ descriptionLbl1��5   g   $��Model��6   $��30.329��6    $
��Left=�60   $��29.727,0,0,136.329q�6K    J� RenderTransformOrigin$ -0.25,0.462&�6�   $��Bottom=�6�   $��51.217��6�   $
��Bold"�6�   �� 5   
   $��Serial��6   $
��Left=�6!   $��36.137,0,0,106.474q�6<   $ 0.487,-0.271&�6X   $��45.04��6}   $��30.328��6�   $��Bottom=�6�   �� 5   
   -   5        $ serial��5   H   $
��Left=�6   $��79.95,0,0,111.147q�6-   $
 Wrap=�6X   $��134.853��6l   $��25.655��6|   $��Bottom=�6�   $��6��6�   �� 5   
   $��Known Defects ��6   $
��Left=�6)   $��258.492,0,0,140.618q�6D   $��91.329��6a   $��27.716��6p   $��Bottom=�6�   $��Right=�6�   �� 5   
   $��Accessories��6   $
��Left=�6&   $��278.197,0,0,79.901q�6A   $��75.624��6]   $��27.717��6l   $��Bottom=�6|   $��Right=�6�   �� 5   
   $
��Make��6   $
��Left=�6   $��34.001,0,0,170.861q�6:   $ -0.25,0.462&�6V   $��45.482��6z   $
��Bold"�6�   $��25.656��6�   $��Bottom=�6�   �� 5   
   -   5        $
 make��5   H   $
��Left=�6   $��79.95,0,0,170.861q�6-   $
 Wrap=�6V   $��134.853��6j   $��4��6z   $��25.656��6�   $��Bottom=�6�   �� 5   
   $
��Type��6   $
��Left=�6   $��38.304,174.714,0,197.849q�6:   $ 0.544,0.262&�6\   $��41.179��6�   $
��Bold"�6�   �� 5   
   $��	ETA(days)��6   $��26.729��6$   $��Right=�64   $��0,0,66,305.762q�6P   $��Bottom=�6h   $��68.627��6�   $
��Bold"�6�   �� 5   
   $��
Ticket No:��6   $��26.728��6%   $��Right=�65   $��	0,10,71,0q�6Q   $	��Top=�6d   $��63.627��6|   $��Right=�6�   �� 5   
   -   5        $ descriptionLbl��5   C   $��Description��6   $��0,0,198.179,201.147q�6&   $��Right=�6[   $��Bottom=�6~   $��Bottom=�6�   $
��Bold"�6�   $��Right=�6�   $��75.624��6�   �� 5   
   -	   5         ��Name$ acadaptorChbx��5   o   $��
AC Adapter��6   $��19.945��6(   $
��Left=�68   $��79.483,291.981,0,0q�6S   $	��Top=�6�   $��111.582��6�   $��7��6�   �� 5    
   -
   5        $ adapterbrandTxtbx��5    j   $��25.655��6   $
��Left=�6"   {�.  $��79.95,311.002,0,0q�6O   $
 Wrap=�6�   $	��Top=�6�   $��134.853��6�   $��8��6�   �� 5!   
   -   5        $ acadapterbrandLbl��5!   g   $��Brand��6   $��26.729��6    $
��Left=�60   $��35.653,311.002,0,0q�6K   $	��Top=�6�   $��43.83��6�   �� 5"   
   -   5        $ defects��5"   2   $��353.821,0,12.52,140.49q�6   $ 
1.25,0.339&�6C   $
 Wrap=�6f   $��181.659��6z   $��25.656��6�   $��Bottom=�6�   $��11��6�   �� 5#   
   -   5        $ descriptionTextBox��5#   O   $��Right=�6   $��0,170.893,12.52,171.593q�6.   $ 
1.25,0.339&�6k   $
 Wrap=�6�   $��181.659��6�   $��10��6�   �� 5$   
   -   5        $ accessories��5$   B   $��41.096��6   $��353.821,291.51,12.52,0q�6"   $ 
1.25,0.339&�6W   $
 Wrap=�6z   $	��Top=�6�   $��181.659��6�   $��13��6�   �� 5%   
   -   5        $ ticketNoLbl��5%      $	��N/A��6%   $��Right=�63   $	��Top=�6O   $��
0,9.04,8,0q�6g   $��51.921��6{   $��Right=�6�   �� 5&   
   -   5        $ dateCreatedlbl��5&      $�� ��6(   $��Right=�63   $	��Top=�6O   $��0,35,8,0q�6g   $��73��6y   $��Right=�6�   �� 5'   
   -   5        $ 
lblMessage��5'      $��Bottom=�6$   $��	43,0,0,16q�6?   $
��Left=�6R   �� 5(   
   $��Customer Info��6   $	��Top=�6*   $��79.483,87.509,198.179,0q�6B   $��77.346��6c   .��5)      � .+�5*      �� -   5        $ customerAddressLabel��5*      $��Address��60   $��253.87��6B   �� 5+      -   5        $ customerCityStateZipLabel��5+      $��City, State, Zip��65   $��256.677��6P   5,      5-      /  )Telerik.Windows.Controls.RadNumericUpDown  5.   
   -   5          Name$	 eta��5.   #   $��Right=�60   $��0,66.767,8,0q�6L   +  %Telerik.Windows.Controls.RadRangeBase   Minimum$ 0Q�6b   $	��Top=�6n   $��46��6�      ValueFormat$ Numeric=�6�      NumberDecimalDigits$ 0��6�   $��9��6�     5/   
   -   5        $ typeView��5/      $��80.523,174.714,0,0q�60   $	��Top=�6L   $
��Left=�6d   $��134.28��6   $��22.61��6�    . $
 TrueX�6�   $ Visible=�6�   $ Clear Selection��6�   $ Select a type...��6(  $��3��6E  .@�50      .  (Telerik.Windows.Controls.RadComboBoxItem  $��Desktop��6&     51      $��Laptop��6&     52      $��Netbook��6&   53      (  "Telerik.Windows.Controls.RadButton  54   
   -   5          Name$ 	cancelBtn��54      $��Close��6/   $��Right=�6W   $��0,0,12.52,10.049q�6s   $��Bottom=�6�   $��80.144��6�   $��22.61��6�   $��17��6�     55   
   -   5        $ saveBtn��55      $
��Save��6-   $��Right=�6X   $��0,0,114.035,10.049q�6t   $��Bottom=�6�   $��80.144��6�   $��22.61��6�   $ -0.603,0.737&�6�   $��14��6�     56   
   -   5        $ printBtn��56      $��Print��6.   $��Right=�6U   $��0,0,114.035,36.659q�6q   $��Bottom=�6�   $��80.144��6�   $��22.61��6�   $ -0.603,0.737&�6�   $��15��6�   {�.  6�     57   
   -   5        $ newCustomerButton��57      $��New Customer��67   $
��Left=�6k   $��79.483,62.106,0,0q�6�   $	��Top=�6�   $��89.41��6�   $��22.61��6�   $ -0.603,0.737&�6�   $��2��6�     58   
   -   5        $ ClearBtn��58      $��Clear��6.   $��0,0,12.52,36.659q�6>   $��Bottom=�6X   $��22.61��6s   $��Right=�6�   $��80.144��6�   $��16��6�   �� 59   
   $��Date Created��6   $
��Left=�6'   $��397.453,36.549,0,0q�6B   $	��Top=�6^   $ 0.095,0.364&�6v   $��Right=�6�   �� 5:   
   -   5        $ Passwordlbl��5:      $��Password��6%   $��Right=�68   $��0,0,198.179,109.472q�6T   $��60.993��6q   $��Bottom=�6�   $��Right=�6�   �� 5;   
   -   5        $ PasswordTxtBx��5;   I   $��Right=�6   $��0,0,12.52,111.147q�6.   $
 Wrap=�6`   $��181.659��6t   $��12��6�   $��25.656��6�   $��Bottom=�6�   �� 5<   
   -   5        $ 
titleLabel��5<      $��
New Ticket��6$   $
��Left=�69   $	��Top=�6T   $��8,-4,0,0q�6l   $
��Bold"�6~   $��21.333(�6�   5=      5>      