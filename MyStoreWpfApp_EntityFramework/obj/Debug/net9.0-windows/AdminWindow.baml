   M S B A M L   `   `   `  ����X  TMyStoreWpfApp_EntityFramework, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:MyStoreWpfApp_EntityFrameworkMyStoreWpfApp_EntityFramework  5   	   /    )MyStoreWpfApp_EntityFramework.AdminWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:MyStoreWpfApp_EntityFramework     5   	     � Title$  AdminWindow��5   	   $	��608��6   $
��1127��6*   .��5	      ]� .+�5   
   � $	��Top=�6   $��50��6)   
��� ���.+�5      �� $+��%Hệ thống ADMIN quản trị STORE��6   $��20(�6<   $��Center=�6J   $��Center=�6g   5      �� 5   
   $��Bottom=�6   $��30��6-   
�������.+�5      �� $��Design by: Zienk��6   5      R� 5   
   -   5         R�Name$ 
tvCategory��5      $
��Left=�6'   $	��250��6=   
�������6\   ]� 5   
   
����� �.+�5      �� -   5         ��Name$ 	lvProduct��5      $	��Top=�6*   $	��250��6?   
���� ��$��20(�6a    �� View 5      �� 5      .P�5      �� $��Mã sản phẩm��6)    �� DisplayMemberBinding 5      �� *	ProductId+�� 5      $��Tên sản phẩm��6)    5      �� *ProductName+�� 5      $��Số lượng��6)    5      �� *UnitsInStock+�� 5      $
��Giá��6)    5       �� *	UnitPrice+5!      5#      � 5$      
�������.+�5%      �� $��Mã sản phẩm:��6   $
��Left=�6/   $��	26,22,0,0q�6J   $	��Top=�6]   �� 5&      -   5         ��Name$ txtMa��5&      $
��Left=�6)   $��
115,26,0,0q�6D    �� TextWrapping$
 Wrap=�6X   $�� ��6l   $	��Top=�6t   $	��173��6�   �� 5'      $��Tên sản phẩm:��6   $
��Left=�60   $��	26,64,0,0q�6K   $	��Top=�6^   �� 5(      -   5        $ txtTen��5(      $
��Left=�6*   $��
115,68,0,0q�6E   $
 Wrap=�6Y   $�� ��6m   $	��Top=�6u   $	��173��6�   �� 5)      $��Số lượng:��6   $
��Left=�6,   $��
26,109,0,0q�6G   $	��Top=�6[   �� 5*      -   5        $ 
txtSoLuong��5*      $
��Left=�6.   $��115,113,0,0q�6I   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��173��6�   �� 5+      $��Đơn giá:��6   $
��Left=�6+   $��
26,149,0,0q�6F   $	��Top=�6Z   �� 5,      -   5        $ 	txtDonGia��5,      $
��Left=�6-   $��115,153,0,0q�6H   $
 Wrap=�6]   $�� ��6q   $	��Top=�6y   $	��173��6�   �� 5.      -   5         ��Name$ btnNew��5.      $	��New��6)   $��20(�67   $
��Left=�6E   $��115,190,0,0q�6`   $	��Top=�6u   ���	#FFE52E2E���	#FF7CED2E6�   �� 5/      -   5        $ btnSave��5/      $
��Save��6*   $��20(�69   $
��Left=�6G   $��180,190,0,0q�6b   $	��Top=�6w   ���	#FFE52E2E���	#FF7CED2E6�   �� 50      -	   5        $ 	btnUpdate��50      $��Update��6,   $��20(�6=   $
��Left=�6K   $��243,190,0,0q�6f   $	��Top=�6{   ���	#FFE52E2E���	#FF7CED2E6�   �� 51      -
   5        $ 	btnDelete��51      $��Delete��6,   $��20(�6=   $
��Left=�6K   $��335,190,0,0q�6f   $	��Top=�6{    J� RenderTransformOrigin$ 1.689,0.733&�6�   ���	#FFE52E2E���	#FF7CED2E6�   52      53      55      57      