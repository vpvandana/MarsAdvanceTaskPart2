/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 99.95, "KoPercent": 0.05};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.632875, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.765, 500, 1500, "Delete ManageListing"], "isController": false}, {"data": [0.99, 500, 1500, "SignOut"], "isController": false}, {"data": [0.09, 500, 1500, "Search Skill"], "isController": false}, {"data": [0.575, 500, 1500, "Add Education"], "isController": false}, {"data": [0.655, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.4275, 500, 1500, "Add Certification"], "isController": false}, {"data": [0.5425, 500, 1500, "Add Description"], "isController": false}, {"data": [0.2675, 500, 1500, "Update Education"], "isController": false}, {"data": [0.845, 500, 1500, "Add Language"], "isController": false}, {"data": [0.6075, 500, 1500, "View ManageListing"], "isController": false}, {"data": [0.89, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.7975, 500, 1500, "Add Share Skill"], "isController": false}, {"data": [0.3175, 500, 1500, "Update Certification"], "isController": false}, {"data": [0.885, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.01, 500, 1500, "SignIn"], "isController": false}, {"data": [0.5825, 500, 1500, "Update Language"], "isController": false}, {"data": [0.77, 500, 1500, "Delete Certification"], "isController": false}, {"data": [0.765, 500, 1500, "Enable ManageListing"], "isController": false}, {"data": [0.99, 500, 1500, "Delete Skill"], "isController": false}, {"data": [0.885, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 4000, 2, 0.05, 4312.1315, 1, 62704, 429.5, 7006.4000000000015, 36982.5, 61146.99, 29.876386451058742, 16.15979898793741, 19.99350976350973], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Delete ManageListing", 200, 0, 0.0, 1092.9849999999997, 168, 7240, 338.0, 3226.7, 6064.9, 7239.0, 1.6702577207663143, 0.3131733226436839, 0.959093300596282], "isController": false}, {"data": ["SignOut", 200, 0, 0.0, 270.13499999999993, 37, 39175, 64.0, 104.0, 125.89999999999998, 705.9300000000019, 1.5483231660112098, 0.31358836231923326, 0.8406910940451491], "isController": false}, {"data": ["Search Skill", 200, 0, 0.0, 5762.175000000002, 1081, 16388, 5147.5, 10219.7, 12763.499999999975, 15926.530000000002, 1.5353318235903735, 9.798235807776457, 1.1155145280773808], "isController": false}, {"data": ["Add Education", 200, 0, 0.0, 2147.6199999999994, 92, 60442, 1072.0, 2044.0000000000005, 6543.749999999998, 59825.810000000325, 1.8293407970437852, 0.3697983837774058, 1.2398071417464718], "isController": false}, {"data": ["Delete Education", 200, 0, 0.0, 1734.6550000000007, 39, 59608, 789.0, 1142.2000000000003, 1352.2999999999997, 42342.75, 1.770945862184993, 0.37701777144172705, 1.0324752731683993], "isController": false}, {"data": ["Add Certification", 200, 0, 0.0, 1189.3750000000007, 137, 3051, 1438.5, 1858.9, 2016.9999999999995, 2680.3100000000013, 1.760981923520555, 0.35597974430542473, 1.132944229702482], "isController": false}, {"data": ["Add Description", 200, 0, 0.0, 1011.7000000000002, 131, 2525, 314.5, 2068.4, 2268.45, 2495.99, 1.745490089980014, 0.37500763651914365, 1.0261572599296567], "isController": false}, {"data": ["Update Education", 200, 0, 0.0, 26179.78000000001, 240, 62704, 3142.5, 62173.0, 62372.299999999996, 62696.69, 1.7847581652686062, 0.3799321373594503, 1.2793090754952703], "isController": false}, {"data": ["Add Language", 200, 0, 0.0, 3784.1100000000006, 44, 61473, 244.5, 816.3000000000001, 59724.549999999996, 61146.0, 1.9519812609798946, 0.39525714303142695, 1.1424713760247902], "isController": false}, {"data": ["View ManageListing", 200, 0, 0.0, 917.0850000000007, 126, 17800, 253.0, 2006.7, 2171.2, 2734.1900000000032, 1.6866677348895653, 0.6753259485397675, 0.9339263727367028], "isController": false}, {"data": ["Add Skill", 200, 0, 0.0, 346.06000000000006, 37, 1210, 282.0, 855.6, 905.8499999999999, 1190.0500000000009, 1.8722559748368797, 0.4104701819832808, 1.1683316092976233], "isController": false}, {"data": ["Add Share Skill", 200, 0, 0.0, 844.715, 115, 5111, 214.0, 3338.1, 3626.5999999999976, 5058.98, 1.686795762769044, 0.36898657310572835, 3.1149714720666624], "isController": false}, {"data": ["Update Certification", 200, 0, 0.0, 1891.405, 236, 3689, 2309.0, 3149.1000000000004, 3318.9499999999994, 3531.7400000000002, 1.7477323173182797, 0.29868472219794817, 1.2083930475208418], "isController": false}, {"data": ["Delete Language", 200, 2, 1.0, 269.68499999999995, 12, 1358, 107.5, 884.8, 987.8, 1351.3400000000024, 1.8880570948465483, 0.3652947965146466, 1.1042368296217278], "isController": false}, {"data": ["SignIn", 200, 0, 0.0, 27036.614999999987, 884, 38760, 36220.0, 37548.4, 37785.35, 38298.58, 4.665375912664163, 2.2415673330378594, 1.8655125207026055], "isController": false}, {"data": ["Update Language", 200, 0, 0.0, 9987.554999999995, 58, 61281, 551.0, 60179.3, 60468.0, 61044.97, 1.903927803057708, 0.3998434316870704, 1.1934689624069454], "isController": false}, {"data": ["Delete Certification", 200, 0, 0.0, 439.63999999999993, 45, 1151, 165.0, 936.6, 981.8, 1106.4600000000005, 1.748297595216658, 0.3551229490283836, 1.2019545967114522], "isController": false}, {"data": ["Enable ManageListing", 200, 0, 0.0, 796.3549999999998, 120, 7401, 339.0, 3131.9, 3168.2999999999997, 7392.0500000000075, 1.5761434921035211, 0.2924484995113955, 0.8958159300822747], "isController": false}, {"data": ["Delete Skill", 200, 0, 0.0, 234.25500000000008, 1, 33485, 33.0, 157.60000000000002, 229.5499999999999, 1015.2300000000034, 1.8592025880100025, 0.48840380485809637, 1.0022263950991421], "isController": false}, {"data": ["Update Skill", 200, 0, 0.0, 306.72499999999997, 45, 3477, 198.5, 660.0, 710.8, 1610.9500000000046, 1.858960655097735, 0.47200172883340924, 1.1600350181713404], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 2, 100.0, 0.05], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 4000, 2, "500/Internal Server Error", 2, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Delete Language", 200, 2, "500/Internal Server Error", 2, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
