   M S B A M L   `   `   `  ����H  DCompuTrackWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CompuTrackWPFCompuTrackWPF  5   	   %    CompuTrackWPF.ManageUsersWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -localclr-namespace:CompuTrackWPF     5   	   k gTelerik.Windows.Controls.Input, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2010.2.924.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Atelerik1http://schemas.telerik.com/2008/xaml/presentation   5      <d2http://schemas.microsoft.com/expression/blend/2008   5   	   Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   6F     � Title$  ManageUsersWindow��5   	   $	��255��6#   $	��525��60    � WindowStyle$
 None=�5       � 
ResizeMode$ NoResize=�6   
���   ����	#FFFFE773 � WindowStartupLocation$ CenterOwner=�5	   	    � ShowInTaskbar .  $��1q�6C    � 	Resources 5
         CompuTrackWPF.UserData   UserList��%   &	          5   
   6   5      .��5      � $��	0,0,0,-19q�6   .+�5   
   �� $��
12,19,17,7q�6   .+�5      $   CompuTrackWPF.SortableListView  -   5          Name$ userListView��5   ^   $   CompuTrackWPF.SortableListView   SelectionChanged$ userSelectionChange��6�    �� SelectionMode$ Single=�6G   $	��165��6t   $	��180��6�   
	 �� Top$	 16��6  
 �� Left$
 -1��6A  $��1��6R  $ �� IsSynchronizedWithCurrentItem 6�   Z� ��6�   ��  �� Source# [   �� View 5      �� 5      .P�5      ��  �� Width$	 100��6   $
��User��6�    �� DisplayMemberBinding 6   �� *userNameString+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $ 50��6P   $��Level��6[    6   �� *permissionsString+6[   5      5      �� 5      -   5         ��Name$ editUserGroupBox��5      $��	Edit User��6.   $	��184��6A   $	
 173��6N   $	 12��6`   $	��152��6p   .��5      �� .+�5      �� $��	Username:��6   $	��Top=�6'   $
 -4��6?   $	 2��6P   �� 5      -   5         ��Name$ usernameBox��5       �� TextWrapping$
 Wrap=�6*   $	��Top=�6>    �� 	MaxLength$ 15��6V   $
��Left=�6e   $	��132��6�   $��2��6�   $	 22��6�   {�. 6�   �� 5      $��	Password:��6   $	��Top=�6'   $	 50��6?   $
 -4��6O   G� 5      -   5         G�Name$ passwordBox��5      $
��Left=�6.   $	��Top=�6I    G� 	MaxLength$ 15��6a   $	��132��6p   $��3��6|   $	 71��6�   �� 5      -   5         ��Name$ adminCheckBox��5      $��Administrator��6-   $��4��6E   $		 106��6R   (  "Telerik.Windows.Controls.RadButton  5      -   5          Name$ updateButton��5      $��Update��65   $	��Top=�6F   $��5��6^   $		 139��6�     5      -   5        $ deleteUserBtn��5      $��Delete User��66   $	��Top=�6L   $��75��6d   $
 45.617��6�   $		 139��6�   $��6��6�   5       5!      �� 5"      -   5        $ newUserGroupBox��5"      $��New User��6-   $��166.397��6?   $	��184��6O   $	
 333��6\   $	 12��6n   .��5#      �� .+�5$      �� $��	Username:��6   $	��Top=�6'   $	 -3��6?   $
 -4��6O   �� 5%      -	   5        $ newUsernameBox��5%      $
 Wrap=�6-   $	��Top=�6A   $ 15��6Y   $
��Left=�6h   $��7��6�   $	 20.04��6�   $	��132��6�   �� 5&      $��	Password:��6   $	��Top=�6'   $	 37��6?   $
 -4��6O   G� 5'      -
   5        $ newPasswordBox��5'      $
��Left=�61   $	��Top=�6L   $ 15��6d   $��8��6s   $	 58��6�   $	��132��6�   �� 5(      $��	Re-enter:��6   $	��Top=�6'   $	 72��6?   $
 -4��6O   G� 5)      -   5        $ newPasswordConfirmBox��5)      $
��Left=�68   $	��Top=�6S   $ 15��6k   $��9��6z   $	 93��6�   $	��132��6�   �� 5*      -   5        $ newAdminCheckBox��5*      $��Make administrator��60   $��10��6M   $		 119��6[     5+      -   5        $ createUserBtn��5+      $��Create User��66   $	��Top=�6L   $��75��6d   $��11��6o   $		 139��6�   5,      5-        5.      -   5        $ closeBtn��5.      $��Close��6/   $��75��6?   $
 424.397��6a   $	 203.723��6w   $��12��6�   �� 5/      -   5         ��Name$ messageLabel��5/      $�� ��6'   $
 8��62   $		 196��6B   50      �� 51   
   -   5        $ 
titleLabel��51      $��Manage Users��6$   $
��Left=�6;   $	��Top=�6V   $��9,-2,0,0q�6n   $
��Bold"�6�   $��21.333(�6�   52      53      