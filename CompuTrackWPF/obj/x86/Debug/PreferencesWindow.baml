   M S B A M L   `   `   `  ����  CompuTrackWPF%    CompuTrackWPF.PreferencesWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      k gTelerik.Windows.Controls.Input, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Atelerik1http://schemas.telerik.com/2008/xaml/presentation   5      <d2http://schemas.microsoft.com/expression/blend/2008   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6?   -   5          �Name$  Window��5       � Title$ PreferencesWindow��5      $	��434��5	      $	��236��6    � WindowStyle$
 None=�5
       � 
ResizeMode$ NoResize=�6   
���   ����	#FFFFE773 � WindowStartupLocation$ CenterOwner=�5       � ShowInTaskbar .  $��1q�6?   .��5      � -   5         �Name$ 
LayoutRoot��5      .+�5      �� $��Preferences��6
   $
��Left=�6    $	��Top=�6;   $��8,0,0,0q�6S   $
��Bold"�6d   $��21.333(�6v   (  "Telerik.Windows.Controls.RadButton  5   
   -   5          Name$ closeButton��5   �   $��Close��6   $��Right=�6,   $��Bottom=�6H   $��75��6c   $��0,0,17.727,8.85q�6n   $��10��6�   �� 5   
   -   5         ��Name$ emailGroupBox��5      $��Email Settings��6*   $��9,29.75,0,33.127q�6B   $
��Left=�6\   $��211.323��6w   .��5      �� -   5        	 ��Name$	 emailCanvas��5      $��-4.94,-6,-4,2.473q�6'   .+�5      �� $	��To:��6   $��24��6    $��51��6,   

 �� Top$
 5��67     5      -   5        $ test_email_button��5   3   $
��Test��6$   $��21.96��6n   $��75��6}    �� Left$
 43.5��6�   $
 132.128��6�   $��7��6�   �� 5      -   5         ��Name$ Company_Email��5   0   $��Right=�6   $��Company's Email��6G    �� TextWrapping$
 Wrap=�6^   $	��158��6r   $��20.292��6~   $
 43.5��6�   $
 34.96��6�   $��2��6�    �� 	MaxLength$ 30��6�   �� 5      -   5         ��Name$ 
From_label��5   9   $��From:��6   $��24��6"   $��51��6.   $
 29��6M   �� 5      -	   5        $ SMTP_textBox��5      $
 Wrap=�6*   $��SMTP Server��6>   $��20.292��6Q   $
 43.5��6a   $
 83.544��6t   $	��158��6�   $��4��6�   $ 50��6�   G� 5      -
   5         G�Name$ PasswordBox��5       G� Password$ Password��6-   $��20.292��6A   $
 43.5��6Q   $
 59.252��6d   $	��158��6x   $��3��6�    G� 	MaxLength$ 20��6�   �� 5      -   5        $ Port_Textbox��5      $��Right=�6*   $
 Wrap=�6F   $��Port
��6Z   $��34.333��6k   $��20.292��6z   $ 167.167��6�   $
 107.836��6�   $��6��6�   $ 5��6�   �� 5      -   5        $ emailAddressTextBox��5      $��Right=�61   $
 Wrap=�6M   $��Manager's Email��6a   $	��158��6x   $��20.292��6�   $
 43.5��6�   $
 10.668��6�   $��1��6�   $ 30��6�   �� 5      -   5         ��Name$ ssl_checkbox��5   3   $	��SSL��6   $��20.292��6#    d� 	IsChecked$
 TrueY�6I   $
 43.5��6Z   $
 110.836��6m   $��5��6�     5      -   5        $ Save_All_button��5   3   $
��Save��6$   $��Bottom=�6L    J� RenderTransformOrigin$ -0.32,0.681&�6g   $��75��6�   $��21.96��6�   $ 126.5��6�   $
 132.128��6�   $��8��6�   5      5      �� 5   
   -   5        $ connectionGroupBox��5      $��Connection String��6/   $
��Left=�6J   $��223.323,29.75,0,33.127q�6e   $��190.95��6�   .��5      �� -   5        $	 connectionCanvas��5      .+�5         -   5        $ changeButton��5    [   $��Change Connection��6$   $ 33��6q   $
 122.696��6�   $	��117��6�   $��9��6�   �� 5!      $
��Left=�6   $
��Wrap=�61   $����Here you can change the connection string used by the program to specify which SQL server it connects to. You can also specify timeout durations and other settings. A program restart is required.��6E   $	��Top=�6  $
 9.19��6(  $
 4��6;  $��161.76��6J  5"      5#      5$      5%      