# -*- coding: utf-8 -*-

# Form implementation generated from reading ui file 'c:\Users\vuduc\OneDrive\Documents\ArtificialIntelligent\ui\first_version.ui'
#
# Created by: PyQt5 UI code generator 5.9.2
#
# WARNING! All changes made in this file will be lost!

from PyQt5 import QtCore, QtWidgets
#from PyQt5.QtWidgets import QApplication, QTableView
#from PyQt5.QtCore import QAbstractTableModel, Qt

import sys
import pandas as pd

import requests

from PyQt5.QtGui import QImage, QPixmap
from langdetect import detect
from iso639 import languages
#from langcodes import *

import readbookdataset
books = readbookdataset.book
user = readbookdataset.user
rating = readbookdataset.rating


BOOK = " "
df = pd.DataFrame()

class Ui_MainWindow(object):
    
    def setupUi(self, MainWindow):
        MainWindow.setObjectName("MainWindow")
        MainWindow.resize(1084, 600)
        self.centralwidget = QtWidgets.QWidget(MainWindow)
        self.centralwidget.setObjectName("centralwidget")
        self.gridLayout = QtWidgets.QGridLayout(self.centralwidget)
        self.gridLayout.setObjectName("gridLayout")
        self.frame = QtWidgets.QFrame(self.centralwidget)
        self.frame.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame.setObjectName("frame")
        self.gridLayout_5 = QtWidgets.QGridLayout(self.frame)
        self.gridLayout_5.setObjectName("gridLayout_5")
        self.frame_2 = QtWidgets.QFrame(self.frame)
        self.frame_2.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_2.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_2.setObjectName("frame_2")
        self.gridLayout_2 = QtWidgets.QGridLayout(self.frame_2)
        self.gridLayout_2.setObjectName("gridLayout_2")
        self.verticalLayout = QtWidgets.QVBoxLayout()
        self.verticalLayout.setObjectName("verticalLayout")
        self.horizontalLayout = QtWidgets.QHBoxLayout()
        self.horizontalLayout.setObjectName("horizontalLayout")
        self.label = QtWidgets.QLabel(self.frame_2)
        self.label.setObjectName("label")
        self.horizontalLayout.addWidget(self.label)
        self.lineEdit = QtWidgets.QLineEdit(self.frame_2)
        self.lineEdit.setText("")
        self.lineEdit.setObjectName("lineEdit")
        self.horizontalLayout.addWidget(self.lineEdit)
        self.pushButton = QtWidgets.QPushButton(self.frame_2)
        self.pushButton.setObjectName("pushButton")
        self.horizontalLayout.addWidget(self.pushButton)
        self.verticalLayout.addLayout(self.horizontalLayout)
        self.line = QtWidgets.QFrame(self.frame_2)
        self.line.setFrameShape(QtWidgets.QFrame.HLine)
        self.line.setFrameShadow(QtWidgets.QFrame.Sunken)
        self.line.setObjectName("line")
        self.verticalLayout.addWidget(self.line)
        self.horizontalLayout_2 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_2.setObjectName("horizontalLayout_2")
        self.label_3 = QtWidgets.QLabel(self.frame_2)
        self.label_3.setObjectName("label_3")
        self.horizontalLayout_2.addWidget(self.label_3)
        self.label_6 = QtWidgets.QLabel(self.frame_2)
        self.label_6.setObjectName("label_6")
        self.horizontalLayout_2.addWidget(self.label_6)
        spacerItem = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_2.addItem(spacerItem)
        self.verticalLayout.addLayout(self.horizontalLayout_2)
        self.horizontalLayout_3 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_3.setObjectName("horizontalLayout_3")
        self.label_2 = QtWidgets.QLabel(self.frame_2)
        self.label_2.setObjectName("label_2")
        self.horizontalLayout_3.addWidget(self.label_2)
        self.label_7 = QtWidgets.QLabel(self.frame_2)
        self.label_7.setObjectName("label_7")
        self.horizontalLayout_3.addWidget(self.label_7)
        spacerItem1 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_3.addItem(spacerItem1)
        self.verticalLayout.addLayout(self.horizontalLayout_3)
        self.horizontalLayout_4 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_4.setObjectName("horizontalLayout_4")
        self.label_4 = QtWidgets.QLabel(self.frame_2)
        self.label_4.setObjectName("label_4")
        self.horizontalLayout_4.addWidget(self.label_4)
        self.label_8 = QtWidgets.QLabel(self.frame_2)
        self.label_8.setObjectName("label_8")
        self.horizontalLayout_4.addWidget(self.label_8)
        spacerItem2 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_4.addItem(spacerItem2)
        self.verticalLayout.addLayout(self.horizontalLayout_4)
        self.horizontalLayout_5 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_5.setObjectName("horizontalLayout_5")
        self.label_5 = QtWidgets.QLabel(self.frame_2)
        self.label_5.setObjectName("label_5")
        self.horizontalLayout_5.addWidget(self.label_5)
        spacerItem3 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_5.addItem(spacerItem3)
        self.verticalLayout.addLayout(self.horizontalLayout_5)
        self.tableWidget = QtWidgets.QTableWidget(self.frame_2)
        self.tableWidget.setObjectName("tableWidget")
        self.tableWidget.setColumnCount(2)
        self.tableWidget.setRowCount(0)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget.setHorizontalHeaderItem(0, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget.setHorizontalHeaderItem(1, item)
        self.verticalLayout.addWidget(self.tableWidget)
        # spacerItem4 = QtWidgets.QSpacerItem(20, 40, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        # self.verticalLayout.addItem(spacerItem4)
        self.gridLayout_2.addLayout(self.verticalLayout, 0, 0, 1, 1)
        self.gridLayout_5.addWidget(self.frame_2, 0, 0, 1, 1)
        self.line_2 = QtWidgets.QFrame(self.frame)
        self.line_2.setFrameShape(QtWidgets.QFrame.VLine)
        self.line_2.setFrameShadow(QtWidgets.QFrame.Sunken)
        self.line_2.setObjectName("line_2")
        self.gridLayout_5.addWidget(self.line_2, 0, 1, 1, 1)
        self.frame_3 = QtWidgets.QFrame(self.frame)
        self.frame_3.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_3.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_3.setObjectName("frame_3")
        self.gridLayout_3 = QtWidgets.QGridLayout(self.frame_3)
        self.gridLayout_3.setObjectName("gridLayout_3")
        self.tableWidget_2 = QtWidgets.QTableWidget(self.frame_3)
        self.tableWidget_2.setObjectName("tableWidget_2")
        self.tableWidget_2.setColumnCount(4)
        self.tableWidget_2.setRowCount(0)
        item = QtWidgets.QTableWidgetItem()
        # self.tableWidget_2.setVerticalHeaderItem(0, item)
        # item = QtWidgets.QTableWidgetItem()
        self.tableWidget_2.setHorizontalHeaderItem(0, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget_2.setHorizontalHeaderItem(1, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget_2.setHorizontalHeaderItem(2, item)
        item = QtWidgets.QTableWidgetItem()
        self.tableWidget_2.setHorizontalHeaderItem(3, item)
        self.tableWidget_2.horizontalHeader().setVisible(True)
        self.tableWidget_2.horizontalHeader().setCascadingSectionResizes(False)
        self.gridLayout_3.addWidget(self.tableWidget_2, 0, 0, 1, 1)
        self.gridLayout_5.addWidget(self.frame_3, 0, 2, 1, 1)
        self.line_3 = QtWidgets.QFrame(self.frame)
        self.line_3.setFrameShape(QtWidgets.QFrame.VLine)
        self.line_3.setFrameShadow(QtWidgets.QFrame.Sunken)
        self.line_3.setObjectName("line_3")
        self.gridLayout_5.addWidget(self.line_3, 0, 3, 1, 1)
        self.frame_4 = QtWidgets.QFrame(self.frame)
        self.frame_4.setFrameShape(QtWidgets.QFrame.StyledPanel)
        self.frame_4.setFrameShadow(QtWidgets.QFrame.Raised)
        self.frame_4.setObjectName("frame_4")
        self.gridLayout_4 = QtWidgets.QGridLayout(self.frame_4)
        self.gridLayout_4.setObjectName("gridLayout_4")
        self.horizontalLayout_10 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_10.setObjectName("horizontalLayout_10")
        self.verticalLayout_2 = QtWidgets.QVBoxLayout()
        self.verticalLayout_2.setObjectName("verticalLayout_2")
        self.horizontalLayout_6 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_6.setObjectName("horizontalLayout_6")
        self.label_9 = QtWidgets.QLabel(self.frame_4)
        self.label_9.setObjectName("label_9")
        self.horizontalLayout_6.addWidget(self.label_9)
        self.label_10 = QtWidgets.QLabel(self.frame_4)
        self.label_10.setObjectName("label_10")
        self.horizontalLayout_6.addWidget(self.label_10)
        self.verticalLayout_2.addLayout(self.horizontalLayout_6)
        self.horizontalLayout_7 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_7.setObjectName("horizontalLayout_7")
        self.label_11 = QtWidgets.QLabel(self.frame_4)
        self.label_11.setObjectName("label_11")
        self.horizontalLayout_7.addWidget(self.label_11)
        self.label_12 = QtWidgets.QLabel(self.frame_4)
        self.label_12.setObjectName("label_12")
        self.horizontalLayout_7.addWidget(self.label_12)
        self.verticalLayout_2.addLayout(self.horizontalLayout_7)
        self.horizontalLayout_8 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_8.setObjectName("horizontalLayout_8")
        self.label_13 = QtWidgets.QLabel(self.frame_4)
        self.label_13.setObjectName("label_13")
        self.horizontalLayout_8.addWidget(self.label_13)
        self.label_14 = QtWidgets.QLabel(self.frame_4)
        self.label_14.setObjectName("label_14")
        self.horizontalLayout_8.addWidget(self.label_14)
        self.verticalLayout_2.addLayout(self.horizontalLayout_8)
        self.horizontalLayout_9 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_9.setObjectName("horizontalLayout_9")
        self.label_15 = QtWidgets.QLabel(self.frame_4)
        self.label_15.setObjectName("label_15")
        self.horizontalLayout_9.addWidget(self.label_15)
        self.label_16 = QtWidgets.QLabel(self.frame_4)
        self.label_16.setObjectName("label_16")
        self.horizontalLayout_9.addWidget(self.label_16)
        self.verticalLayout_2.addLayout(self.horizontalLayout_9)
        spacerItem5 = QtWidgets.QSpacerItem(20, 40, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        self.verticalLayout_2.addItem(spacerItem5)
        self.horizontalLayout_10.addLayout(self.verticalLayout_2)
        self.label_17 = QtWidgets.QLabel(self.frame_4)
        self.label_17.setFrameShape(QtWidgets.QFrame.WinPanel)
        self.label_17.setFrameShadow(QtWidgets.QFrame.Sunken)
        self.label_17.setLineWidth(7)
        self.label_17.setText("")
        self.label_17.setObjectName("label_17")
        self.horizontalLayout_10.addWidget(self.label_17)
        self.gridLayout_4.addLayout(self.horizontalLayout_10, 0, 0, 1, 1)
        self.horizontalLayout_11 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_11.setObjectName("horizontalLayout_11")
        self.label_18 = QtWidgets.QLabel(self.frame_4)
        self.label_18.setObjectName("label_18")
        self.horizontalLayout_11.addWidget(self.label_18)
        self.label_19 = QtWidgets.QLabel(self.frame_4)
        self.label_19.setObjectName("label_19")
        self.horizontalLayout_11.addWidget(self.label_19)
        spacerItem6 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_11.addItem(spacerItem6)
        self.gridLayout_4.addLayout(self.horizontalLayout_11, 1, 0, 1, 1)
        self.horizontalLayout_12 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_12.setObjectName("horizontalLayout_12")
        self.label_20 = QtWidgets.QLabel(self.frame_4)
        self.label_20.setObjectName("label_20")
        self.horizontalLayout_12.addWidget(self.label_20)
        self.label_21 = QtWidgets.QLabel(self.frame_4)
        self.label_21.setObjectName("label_21")
        self.horizontalLayout_12.addWidget(self.label_21)
        spacerItem7 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_12.addItem(spacerItem7)
        self.gridLayout_4.addLayout(self.horizontalLayout_12, 2, 0, 1, 1)
        self.horizontalLayout_13 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_13.setObjectName("horizontalLayout_13")
        self.label_22 = QtWidgets.QLabel(self.frame_4)
        self.label_22.setObjectName("label_22")
        self.horizontalLayout_13.addWidget(self.label_22)
        self.label_23 = QtWidgets.QLabel(self.frame_4)
        self.label_23.setObjectName("label_23")
        self.horizontalLayout_13.addWidget(self.label_23)
        spacerItem8 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_13.addItem(spacerItem8)
        self.gridLayout_4.addLayout(self.horizontalLayout_13, 3, 0, 1, 1)
        self.horizontalLayout_14 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_14.setObjectName("horizontalLayout_14")
        self.label_24 = QtWidgets.QLabel(self.frame_4)
        self.label_24.setObjectName("label_24")
        self.horizontalLayout_14.addWidget(self.label_24)
        self.label_25 = QtWidgets.QLabel(self.frame_4)
        self.label_25.setObjectName("label_25")
        self.horizontalLayout_14.addWidget(self.label_25)
        spacerItem9 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_14.addItem(spacerItem9)
        self.gridLayout_4.addLayout(self.horizontalLayout_14, 4, 0, 1, 1)
        self.verticalLayout_3 = QtWidgets.QVBoxLayout()
        self.verticalLayout_3.setObjectName("verticalLayout_3")
        self.horizontalLayout_15 = QtWidgets.QHBoxLayout()
        self.horizontalLayout_15.setObjectName("horizontalLayout_15")
        self.label_26 = QtWidgets.QLabel(self.frame_4)
        self.label_26.setObjectName("label_26")
        self.horizontalLayout_15.addWidget(self.label_26)
        spacerItem10 = QtWidgets.QSpacerItem(40, 20, QtWidgets.QSizePolicy.Expanding, QtWidgets.QSizePolicy.Minimum)
        self.horizontalLayout_15.addItem(spacerItem10)
        self.verticalLayout_3.addLayout(self.horizontalLayout_15)
        self.label_27 = QtWidgets.QLabel(self.frame_4)
        self.label_27.setObjectName("label_27")
        self.verticalLayout_3.addWidget(self.label_27)
        self.gridLayout_4.addLayout(self.verticalLayout_3, 5, 0, 1, 1)
        spacerItem11 = QtWidgets.QSpacerItem(20, 164, QtWidgets.QSizePolicy.Minimum, QtWidgets.QSizePolicy.Expanding)
        self.gridLayout_4.addItem(spacerItem11, 6, 0, 1, 1)
        self.gridLayout_5.addWidget(self.frame_4, 0, 4, 1, 1)
        self.gridLayout.addWidget(self.frame, 0, 1, 1, 1)
        MainWindow.setCentralWidget(self.centralwidget)
        self.menubar = QtWidgets.QMenuBar(MainWindow)
        self.menubar.setGeometry(QtCore.QRect(0, 0, 1084, 21))
        self.menubar.setObjectName("menubar")
        MainWindow.setMenuBar(self.menubar)
        self.statusbar = QtWidgets.QStatusBar(MainWindow)
        self.statusbar.setObjectName("statusbar")
        MainWindow.setStatusBar(self.statusbar)

        self.retranslateUi(MainWindow)
        QtCore.QMetaObject.connectSlotsByName(MainWindow)

        #hookup buttons:
        self.pushButton.clicked.connect(self.Block)
        self.lineEdit.returnPressed.connect(self.Block)
        self.tableWidget.selectionModel().selectionChanged.connect(self.onSelection)
        #self.tableWidget.selectionModel().selectionChanged.connect(self.bookShow)


    def retranslateUi(self, MainWindow):
        _translate = QtCore.QCoreApplication.translate
        MainWindow.setWindowTitle(_translate("MainWindow", "MainWindow"))
        self.label.setText(_translate("MainWindow", "UID"))
        self.pushButton.setText(_translate("MainWindow", "Go"))
        self.label_3.setText(_translate("MainWindow", "Age:"))
        self.label_6.setText(_translate("MainWindow", "..."))
        self.label_2.setText(_translate("MainWindow", "Location:"))
        self.label_7.setText(_translate("MainWindow", "..."))
        self.label_4.setText(_translate("MainWindow", "Language:"))
        self.label_8.setText(_translate("MainWindow", "..."))
        self.label_5.setText(_translate("MainWindow", "Recent:"))
        item = self.tableWidget.horizontalHeaderItem(0)
        item.setText(_translate("MainWindow", "Book"))
        item = self.tableWidget.horizontalHeaderItem(1)
        item.setText(_translate("MainWindow", "Rate"))
        item = self.tableWidget_2.horizontalHeaderItem(0)
        item.setText(_translate("MainWindow", "Title"))
        item = self.tableWidget_2.horizontalHeaderItem(1)
        item.setText(_translate("MainWindow", "Author"))
        item = self.tableWidget_2.horizontalHeaderItem(2)
        item.setText(_translate("MainWindow", "Views"))
        item = self.tableWidget_2.horizontalHeaderItem(3)
        item.setText(_translate("MainWindow", "Rate"))
        self.label_9.setText(_translate("MainWindow", "Views:"))
        self.label_10.setText(_translate("MainWindow", "..."))
        self.label_11.setText(_translate("MainWindow", "Rate:"))
        self.label_12.setText(_translate("MainWindow", "..."))
        self.label_13.setText(_translate("MainWindow", "Language:"))
        self.label_14.setText(_translate("MainWindow", "..."))
        self.label_15.setText(_translate("MainWindow", "ISBN:"))
        self.label_16.setText(_translate("MainWindow", "..."))
        self.label_18.setText(_translate("MainWindow", "Title:"))
        self.label_19.setText(_translate("MainWindow", "..."))
        self.label_20.setText(_translate("MainWindow", "Writen by:"))
        self.label_21.setText(_translate("MainWindow", "..."))
        self.label_22.setText(_translate("MainWindow", "Year:"))
        self.label_23.setText(_translate("MainWindow", "..."))
        self.label_24.setText(_translate("MainWindow", "Published by:"))
        self.label_25.setText(_translate("MainWindow", "..."))
        self.label_26.setText(_translate("MainWindow", "Plots:"))
        self.label_27.setText(_translate("MainWindow", "..."))
        #Format tableWidget\

        self.tableWidget.setColumnWidth(0,240)
        self.tableWidget.setColumnWidth(1,50)
        self.tableWidget_2.setColumnWidth(0,180)
        self.tableWidget_2.setColumnWidth(1,70)
        self.tableWidget_2.setColumnWidth(2,30)
        self.tableWidget_2.setColumnWidth(3,30)

    def find(self, UID):
        dataset = pd.DataFrame()
        loc = user.loc[user['User-ID'] == int(UID), 'Location'].values[0]
        age = str(user.loc[user['User-ID'] == int(UID), 'Age'].values[0])
        if age == "nan": age = "Unknown"
        users = pd.DataFrame({"uid":[UID], "loc":[loc], "age":[age]})
        dataset = pd.concat([dataset, users], ignore_index=True)
        try:
            read = rating.loc[rating['User-ID'] == int(UID), 'ISBN']
            readd = pd.DataFrame(read)
            if len(read)>=1:
                for rowe in readd.iterrows():
                    lang=[]
                    isbn = rowe[1].values[0]
                    try:
                        book = books.loc[books['ISBN'] == isbn, 'Book-Title'].values[0]
                        l_url = books.loc[books['ISBN'] == isbn, 'Image-URL-L'].values[0]
                        author = books.loc[books['Book-Title'] == book, 'Book-Author'].values[0]
                        year = books.loc[books['Book-Title'] == book, 'Year-Of-Publication'].values[0]
                        publisher = books.loc[books['Book-Title'] == book, 'Publisher'].values[0]
                        isbn = str(books.loc[books['Book-Title'] == book, 'ISBN'].values[0])
                        try:
                            text = book +" "+ author +" "+ publisher
                            code = detect(text)
                            lang = languages.make(alpha2=code).name
                            
                        except:
                            pass
                        rates = rating.loc[rating['ISBN'] == isbn, 'Book-Rating']
                        l=int(len(rates))
                        rates = pd.DataFrame(rates)
                        if l>=1:
                            total_rate = 0
                            for r in rates.iterrows():
                                total_rate = total_rate + int(r[1].values[0])
                            rate = round(total_rate/l, 1)

                        else:
                            rate = 0
                        
                        data = pd.DataFrame({"uid":[UID], "loc":[loc], "age":[age], "book":[book],"isbn":[str(isbn)], "author":[author], "year":[str(year)], "publisher":[publisher], "rate":[str(rate)], "url":[l_url], "lang":[lang]})
                        dataset=pd.concat([dataset, data], ignore_index=True)           
                    except:
                        pass
        except:
            pass
        return dataset

    def onSelection(self, selected):
        try:
            for ix in selected.indexes():
                x=ix.row()
                y=ix.column()
            a = self.tableWidget.item(int(x), int(y)).text()
            self.label_19.setText(f"{str(a)}")
            self.bookShow(a)
        except:
            print("Unknown selection!")
            pass
    
    def image_show(self, url):
        try:
            image = QImage()
            image.loadFromData(requests.get(url).content)
            print(requests.get(url).content)
            self.label_17.setPixmap(QPixmap(image))
            self.label_17.show()
        except:
            print("error link: ", url)
            self.label_17.setText(" ")
            pass


    def bookShow(self, book):
        try:
            rate = df.loc[df['book']==book, 'rate'].values[0]
            lang = df.loc[df['book']==book, 'lang'].values[0]
            isbn = df.loc[df['book']==book, 'isbn'].values[0]
            author = df.loc[df['book']==book, 'author'].values[0]
            year = df.loc[df['book']==book, 'year'].values[0]
            publisher = df.loc[df['book']==book, 'publisher'].values[0]
            url = df.loc[df['book']==book, 'url'].values[0]

            self.label_16.setText(f"{isbn}")
            self.label_12.setText(f"{rate}")
            self.label_14.setText(f"{lang}")
            self.label_21.setText(f"{author}")
            self.label_23.setText(f"{year}")
            self.label_25.setText(f"{publisher}")
            self.image_show(url)
        except:
            self.label_19.setText(" ")
            self.label_16.setText(" ")
            self.label_12.setText(" ")
            self.label_14.setText(" ")
            self.label_21.setText(" ")
            self.label_23.setText(" ")
            self.label_25.setText(" ")
            self.label_17.setText(" ")
            pass
    
    def readTableRecent(self, dataFrame):
            self.tableWidget.clear()
            B = pd.concat([dataFrame.loc[:,"book"]], axis=1)
            R = pd.concat([dataFrame.loc[:, "rate"]], axis=1)
            
            for row_numberB, row_data in B.iterrows():
                dataB = row_data.values[0]
                self.tableWidget.insertRow(int(row_numberB))
                try:
                    self.tableWidget.setItem(row_numberB,0,QtWidgets.QTableWidgetItem(dataB))
                except:
                    pass
            for row_numberR, row_data in R.iterrows():
                dataR = row_data.values[0]
                try:
                    self.tableWidget.setItem(row_numberR,1,QtWidgets.QTableWidgetItem(dataR))
                except:
                    pass
            for row, data in self.tableWidget.rowCount():
                if data == None:
                    self.tableWidget.removeRow(row)

    def Block(self):
        uid = self.lineEdit.text()
        try:
            global df 
            df = self.find(uid)
            age = df.loc[1,"age"]
            loc = df.loc[1, "loc"]
            lang = df.loc[1, "lang"]
            print("accepted", uid)
            self.label_6.setText(f"{age}")
            self.label_7.setText(f"{loc}")
            self.label_8.setText(f"{lang}")
            self.readTableRecent(df)
            

            

        except:
            print("denied", uid)
            pass

if __name__ == '__main__':
    app = QtWidgets.QApplication(sys.argv)
    style = """
        QWidget{
            background: #262D37;
        }

        QLabel{
            color: #fff;
        }

        QLabel#lable_17, QLabel#lable_27{
            border: 1px solid #fff;
            border-radius: 8px;
            padding: 2px;
        }
        QPushButton
        {
            color: white;
            background: #0577a8;
            border: 1px #DADADA solid;
            padding: 5px 10px;
            border-radius: 2px;
            font-weight: bold;
            font-size: 9pt;
            outline: none;
        }
        QTableWidget
        {
            border: 1px #DADADA solid;
            background: #262D37;
            color: white;
            selection-color: black;
            selection-background-color: qlineargradient(x1: 0, y1: 0, x2: 0.5, y2: 0.5,stop: 0 #FF92BB, stop: 1 white);
        }
        QTableWidgetItem
        {
            border: 1px #DADADA solid;
            background: #262D37;
            color: white;
            selection-background-color: qlineargradient(x1: 0, y1: 0, x2: 0.5, y2: 0.5,stop: 0 #FF92BB, stop: 1 white);
        }

        QPushButton:hover{
            border: 1px #C6C6C6 solid;
            color: #fff;
            background: #0892D0;
        }

        QLineEdit {
            padding: 1px;
            color: #fff;
            border-style: solid;
            border: 2px solid #fff;
            border-radius: 8px;
        }

    """
    app.setStyleSheet(style)
    MainWindow = QtWidgets.QMainWindow()
    ui = Ui_MainWindow()
    ui.setupUi(MainWindow)
    MainWindow.show()
    sys.exit(app.exec_())