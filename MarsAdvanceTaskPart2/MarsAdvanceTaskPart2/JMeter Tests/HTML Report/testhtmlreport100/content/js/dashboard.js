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

    var data = {"OkPercent": 99.8, "KoPercent": 0.2};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.683, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.935, 500, 1500, "Delete ManageListing"], "isController": false}, {"data": [0.705, 500, 1500, "SignOut"], "isController": false}, {"data": [0.08, 500, 1500, "Search Skill"], "isController": false}, {"data": [0.64, 500, 1500, "Add Education"], "isController": false}, {"data": [0.915, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.615, 500, 1500, "Add Certification"], "isController": false}, {"data": [0.38, 500, 1500, "Add Description"], "isController": false}, {"data": [0.5, 500, 1500, "Update Education"], "isController": false}, {"data": [0.835, 500, 1500, "Add Language"], "isController": false}, {"data": [0.765, 500, 1500, "View ManageListing"], "isController": false}, {"data": [0.965, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.855, 500, 1500, "Add Share Skill"], "isController": false}, {"data": [0.37, 500, 1500, "Update Certification"], "isController": false}, {"data": [0.955, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.0, 500, 1500, "SignIn"], "isController": false}, {"data": [0.73, 500, 1500, "Update Language"], "isController": false}, {"data": [0.455, 500, 1500, "Delete Certification"], "isController": false}, {"data": [0.995, 500, 1500, "Enable ManageListing"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skill"], "isController": false}, {"data": [0.965, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 2000, 4, 0.2, 4896.121499999997, 2, 87041, 351.0, 2912.000000000002, 12703.549999998868, 85464.77, 18.41756298806542, 9.974765060962133, 12.324892861582805], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Delete ManageListing", 100, 0, 0.0, 329.81000000000006, 154, 1139, 252.0, 699.9000000000002, 827.4499999999998, 1138.7299999999998, 1.1577289987959618, 0.21707418727424282, 0.6647896985273687], "isController": false}, {"data": ["SignOut", 100, 0, 0.0, 847.3000000000003, 38, 3619, 112.0, 2882.4000000000005, 3175.749999999999, 3617.349999999999, 1.1119265238953009, 0.2245461776135833, 0.6037413547712768], "isController": false}, {"data": ["Search Skill", 100, 0, 0.0, 3862.7900000000004, 1025, 6786, 3672.0, 6211.8, 6392.65, 6784.389999999999, 1.0923947477660527, 6.971484059229643, 0.7936930589237727], "isController": false}, {"data": ["Add Education", 100, 0, 0.0, 631.9299999999997, 88, 1834, 643.5, 1020.0000000000001, 1110.0999999999995, 1827.1899999999964, 1.2877636696113528, 0.26031941368120126, 0.8727617057717568], "isController": false}, {"data": ["Delete Education", 100, 0, 0.0, 296.1700000000001, 37, 2377, 174.0, 640.0000000000003, 722.9, 2376.5099999999998, 1.2344307422632053, 0.2627987322396277, 0.7196827667296226], "isController": false}, {"data": ["Add Certification", 100, 0, 0.0, 804.0700000000005, 86, 3256, 633.0, 1437.4, 2751.2499999999995, 3255.79, 1.1958861516383639, 0.24174651698158334, 0.7693845670892131], "isController": false}, {"data": ["Add Description", 100, 0, 0.0, 1627.0800000000004, 122, 3960, 1900.5, 2948.3, 3406.349999999999, 3958.499999999999, 1.1657864978607817, 0.25046194289977736, 0.6853549528439362], "isController": false}, {"data": ["Update Education", 100, 0, 0.0, 1113.5099999999998, 173, 2930, 1183.0, 1598.3, 2035.549999999996, 2924.439999999997, 1.2656305371336, 0.26941615672302943, 0.9072000139219359], "isController": false}, {"data": ["Add Language", 100, 0, 0.0, 408.42, 42, 1879, 251.5, 961.5000000000002, 1484.499999999999, 1877.239999999999, 1.3260137375023204, 0.2680516051396292, 0.7761065170260164], "isController": false}, {"data": ["View ManageListing", 100, 0, 0.0, 495.4800000000003, 114, 1783, 321.0, 901.4000000000001, 1009.3499999999999, 1781.6899999999994, 1.160227404571296, 0.46454417565842904, 0.6424306038983641], "isController": false}, {"data": ["Add Skill", 100, 0, 0.0, 211.33000000000004, 38, 1338, 170.5, 424.6, 572.8999999999997, 1335.5199999999986, 1.3126460318710458, 0.31021517550077443, 0.8191218890289045], "isController": false}, {"data": ["Add Share Skill", 100, 0, 0.0, 385.21000000000004, 130, 979, 244.5, 827.8, 848.8499999999999, 978.4699999999997, 1.155214638879904, 0.252703202254979, 2.1333114083221663], "isController": false}, {"data": ["Update Certification", 100, 2, 2.0, 1516.3799999999999, 151, 3999, 1160.0, 3063.4, 3303.4499999999994, 3993.7799999999975, 1.1615346195393352, 0.1970525333070052, 0.8030922955408686], "isController": false}, {"data": ["Delete Language", 100, 2, 2.0, 187.20999999999998, 34, 1232, 111.0, 328.5000000000002, 965.3999999999942, 1231.94, 1.3151837969356217, 0.2532756296442428, 0.7693311468402709], "isController": false}, {"data": ["SignIn", 100, 0, 0.0, 82688.20000000001, 13015, 87041, 84303.0, 85844.2, 86101.95, 87038.31999999999, 1.1448590106128431, 0.5500689777553894, 0.4571833463084021], "isController": false}, {"data": ["Update Language", 100, 0, 0.0, 632.7199999999999, 148, 2022, 441.0, 1402.7000000000003, 1660.6499999999996, 2021.5699999999997, 1.3125426576363732, 0.2757749538969391, 0.8229027209009293], "isController": false}, {"data": ["Delete Certification", 100, 0, 0.0, 1410.9399999999998, 35, 3573, 2078.0, 2789.5, 3064.6, 3569.209999999998, 1.166616113301757, 0.23687775613056766, 0.8020485778949579], "isController": false}, {"data": ["Enable ManageListing", 100, 0, 0.0, 198.64000000000001, 113, 716, 190.5, 268.9000000000001, 353.9999999999993, 712.5399999999983, 1.1601735619648699, 0.21526657888020048, 0.6593955205698773], "isController": false}, {"data": ["Delete Skill", 100, 0, 0.0, 54.34000000000001, 2, 491, 37.5, 94.9, 179.09999999999934, 490.93999999999994, 1.303916966567569, 0.34253287500651963, 0.7028927397903302], "isController": false}, {"data": ["Update Skill", 100, 0, 0.0, 220.90000000000003, 38, 1554, 166.0, 365.00000000000017, 594.7499999999993, 1551.929999999999, 1.3043591683405942, 0.331184945086479, 0.8139506919625389], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 4, 100.0, 0.2], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 2000, 4, "500/Internal Server Error", 4, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 100, 2, "500/Internal Server Error", 2, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Language", 100, 2, "500/Internal Server Error", 2, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
