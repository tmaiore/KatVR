#!/usr/bin/env python
# -*- coding: utf-8 -*-

# import the necessary packages
import sys
import cv2
import numpy as np
import imutils
import json

# colors
from webcolors import rgb_to_name, CSS3_HEX_TO_NAMES, hex_to_rgb  # python3 -m pip install webcolors
from scipy.spatial import KDTree


def convert_rgb_to_names(rgb_tuple):
    # a dictionary of all the hex and their respective names in css3
    css3_db = CSS3_HEX_TO_NAMES  # css3_hex_to_names
    names = []
    rgb_values = []
    for color_hex, color_name in css3_db.items():
        names.append(color_name)
        rgb_values.append(hex_to_rgb(color_hex))

    kdt_db = KDTree(rgb_values)
    distance, index = kdt_db.query(rgb_tuple)
    return names[index]


class ShapeDetector:
    def __init__(self):
        pass

    def detect(self, c):
        # initialize the shape name and approximate the contour
        shape = "unidentified"
        peri = cv2.arcLength(c, True)
        approx = cv2.approxPolyDP(c, 0.03 * peri, True)

        # if the shape is a triangle, it will have 3 vertices
        if len(approx) == 3:
            shape = "triangle"
        # if the shape has 4 vertices, it is either a square or
        # a rectangle
        elif len(approx) == 4:
            # compute the bounding box of the contour and use the
            # bounding box to compute the aspect ratio
            (x, y, w, h) = cv2.boundingRect(approx)
            ar = w / float(h)
            # a square will have an aspect ratio that is approximately
            # equal to one, otherwise, the shape is a rectangle
            shape = "rectangle"
        # if the shape is a pentagon, it will have 5 vertices
        elif len(approx) == 5:
            shape = "pentagon"
        elif len(approx) == 6:
            shape = "hexagon"
        elif len(approx) == 8:
            shape = "octogon"
        elif len(approx) == 10 or len(approx) == 12:
            shape = "star"
        # otherwise, we assume the shape is a circle
        else:
            shape = "circle"
        # return the name of the shape
        return shape


if __name__ == '__main__':
    # load the image and resize it to a smaller factor so that
    # the shapes can be approximated better
    image = cv2.imread(sys.argv[1])
    resized = imutils.resize(image, width=300)
    ratio = image.shape[0] / float(resized.shape[0])
    # load the json file
    # init tableaux to save
    #f = with open('Assets/mapData/data.json', "w")
    data = []

    '''img = cv2.imread("fleur.png");
    hsv = cv2.cvtColor(img, cv2.COLOR_BGR2HSV)
    h, s, v = cv2.split(hsv)
    ret_h, th_h = cv2.threshold(h, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)
    ret_s, th_s = cv2.threshold(s, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)
    ret_v, th_v = cv2.threshold(s, 0, 255, cv2.THRESH_BINARY + cv2.THRESH_OTSU)
    cv2.imwrite("th_h.png", th_h)
    cv2.imwrite("th_s.png", th_s)
    cv2.imwrite("th_v.png", th_v)'''

    # convert the resized image to grayscale, blur it slightly,
    # and threshold it
    gray = cv2.cvtColor(resized, cv2.COLOR_BGR2GRAY)
    blurred = cv2.GaussianBlur(gray, (5, 5), 0)
    thresh = cv2.threshold(blurred, 60, 255, cv2.THRESH_BINARY)[1]

    # find contours in the thresholded image and initialize the
    # shape detector
    cnts = cv2.findContours(thresh.copy(), cv2.RETR_EXTERNAL,
                            cv2.CHAIN_APPROX_SIMPLE)
    cnts = imutils.grab_contours(cnts)
    sd = ShapeDetector()

    # loop over the contours
    for c in cnts:
        # compute the center of the contour
        M = cv2.moments(c)
        cX = int((M["m10"] / M["m00"]) * ratio)
        cY = int((M["m01"] / M["m00"]) * ratio)
        print(cX, cY)
        rect = cv2.minAreaRect(c)
        box = cv2.boxPoints(rect)
        box = np.intp(box)
        box = np.intp(box * ratio)
        # image = cv2.drawContours(image, [box], 0, (0, 0, 255), 2)

        center = rect[0:1]

        x, y, w, h = cv2.boundingRect(c)
        x, y, w, h = x * ratio, y * ratio, w * ratio, h * ratio
        image = cv2.rectangle(image, (int(x), int(y)), (int(x + w), int(y + h)), (255, 255, 255), 2)

        # detect shape from contour
        shape = sd.detect(c)

        # resize the contour
        c = c.astype("float")
        c *= ratio
        c = c.astype("int")
        #cv2.drawContours(image, [c], -1, (255, 255, 255), 2)

        # draw contour with mask
        mask = np.zeros(image.shape[:2], np.uint8)
        cv2.drawContours(mask, [c], -1, 255, -1)
        img = cv2.cvtColor(image, cv2.COLOR_BGR2HSV)

        # Convert to RGB and get color name
        imgRGB = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
        mean = cv2.mean(imgRGB, mask=mask)[:3]
        d = image[int(center[0][0]), int(center[0][1])]
        named_color = convert_rgb_to_names(mean)  # mean

        # get complementary color for text
        mean2 = (255, 255, 255)

        # display shape name and color
        objLbl = shape + " {}".format(named_color)
        textSize = cv2.getTextSize(objLbl, cv2.FONT_HERSHEY_SIMPLEX, 0.5, 2)[0]
        cv2.putText(image, objLbl, (int(cX - textSize[0] / 2), int(cY + textSize[1] / 2)), cv2.FONT_HERSHEY_SIMPLEX,
                    0.5, mean2, 2)

        print(objLbl)

        # add the data the tab to save
        data.append({
            "shape": shape,
            "color": named_color,
            "X": x,
            "Y": y,
            "width": w,
            "heigth": h,
            "angle": rect[2]
        })

        # show image
        # cv2.imshow("Image", image)
        # cv2.waitKey(0)
    # write data in the jsonfile
    with open('Assets/mapData/data.json', 'w') as file:
       	    json.dump(data, file)
    #json.dump(data, f, indent=2)

    cv2.waitKey(0)
