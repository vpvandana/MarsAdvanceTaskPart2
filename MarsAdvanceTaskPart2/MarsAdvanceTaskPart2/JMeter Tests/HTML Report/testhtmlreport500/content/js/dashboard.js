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

    var data = {"OkPercent": 98.17653276955602, "KoPercent": 1.8234672304439747};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.5062103594080338, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [0.6841397849462365, 500, 1500, "Delete ManageListing"], "isController": false}, {"data": [0.8131720430107527, 500, 1500, "SignOut"], "isController": false}, {"data": [0.09946236559139784, 500, 1500, "Search Skill"], "isController": false}, {"data": [0.3655913978494624, 500, 1500, "Add Education"], "isController": false}, {"data": [0.7029569892473119, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.30913978494623656, 500, 1500, "Add Certification"], "isController": false}, {"data": [0.3682795698924731, 500, 1500, "Add Description"], "isController": false}, {"data": [0.26344086021505375, 500, 1500, "Update Education"], "isController": false}, {"data": [0.553763440860215, 500, 1500, "Add Language"], "isController": false}, {"data": [0.5376344086021505, 500, 1500, "View ManageListing"], "isController": false}, {"data": [0.6048387096774194, 500, 1500, "Add Skill"], "isController": false}, {"data": [0.8346774193548387, 500, 1500, "Add Share Skill"], "isController": false}, {"data": [0.2728494623655914, 500, 1500, "Update Certification"], "isController": false}, {"data": [0.6223118279569892, 500, 1500, "Delete Language"], "isController": false}, {"data": [0.001, 500, 1500, "SignIn"], "isController": false}, {"data": [0.4717741935483871, 500, 1500, "Update Language"], "isController": false}, {"data": [0.4959677419354839, 500, 1500, "Delete Certification"], "isController": false}, {"data": [0.6895161290322581, 500, 1500, "Enable ManageListing"], "isController": false}, {"data": [0.956989247311828, 500, 1500, "Delete Skill"], "isController": false}, {"data": [0.6505376344086021, 500, 1500, "Update Skill"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 7568, 138, 1.8234672304439747, 13338.964852008388, 2, 148590, 933.5, 12794.500000000016, 132153.75, 144856.72, 22.466840036573927, 12.729985553744672, 14.781122811353356], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Delete ManageListing", 372, 0, 0.0, 1666.059139784946, 158, 12327, 353.5, 7188.0, 9231.849999999984, 12317.0, 1.1460011644850543, 0.21487521834094764, 0.6580553561691522], "isController": false}, {"data": ["SignOut", 372, 0, 0.0, 1066.1639784946249, 35, 132716, 82.5, 1327.4999999999998, 1682.8499999999997, 2294.9899999999993, 1.1233206808772773, 0.22781769573560895, 0.6099280259450841], "isController": false}, {"data": ["Search Skill", 372, 0, 0.0, 4780.983870967742, 1049, 12934, 4390.5, 10429.799999999992, 12413.75, 12738.169999999998, 1.1191638762782385, 7.1423202455842665, 0.8131425038584077], "isController": false}, {"data": ["Add Education", 372, 0, 0.0, 4362.849462365599, 87, 134019, 1996.0, 3322.1, 3887.35, 133492.69, 1.2598254532154336, 0.25467174689022926, 0.8538270161440537], "isController": false}, {"data": ["Delete Education", 372, 0, 0.0, 646.8387096774194, 37, 2126, 735.0, 1209.3999999999999, 1333.7499999999998, 1717.08, 1.2412412412412412, 0.2642486236236236, 0.7236533408408409], "isController": false}, {"data": ["Add Certification", 372, 0, 0.0, 1893.6505376344087, 111, 5057, 2031.5, 3518.6, 4269.999999999998, 4823.24, 1.2225621879919417, 0.24713903604915227, 0.7865352912129986], "isController": false}, {"data": ["Add Description", 372, 0, 0.0, 16082.854838709663, 117, 135671, 2246.5, 85881.6, 133935.05, 134625.58, 1.1976934741803686, 0.2573169573434386, 0.7041127650943184], "isController": false}, {"data": ["Update Education", 372, 0, 0.0, 4437.392473118277, 239, 137740, 3639.5, 5256.9, 5674.149999999991, 118074.46999999956, 1.241883523343738, 0.264336457168372, 0.8901782286467809], "isController": false}, {"data": ["Add Language", 372, 0, 0.0, 6908.688172043012, 48, 135376, 442.0, 12096.7, 27630.499999999905, 134513.66999999998, 1.3092644538220315, 0.2647860599850772, 0.7662947551992229], "isController": false}, {"data": ["View ManageListing", 372, 0, 0.0, 5478.594086021507, 127, 134142, 413.5, 4306.5, 5573.949999999997, 133905.43, 1.1899240303878447, 0.4764344262295082, 0.6588739504198321], "isController": false}, {"data": ["Add Skill", 372, 0, 0.0, 4222.129032258065, 39, 133436, 610.0, 2099.7, 2677.199999999999, 132875.06, 1.2744789025777363, 0.2937007938084992, 0.7953047058077866], "isController": false}, {"data": ["Add Share Skill", 372, 0, 0.0, 493.2876344086023, 111, 2426, 236.0, 1648.7, 1828.3999999999999, 2227.399999999998, 1.1898022433529396, 0.26026924073345553, 2.1971836349418052], "isController": false}, {"data": ["Update Certification", 372, 9, 2.4193548387096775, 4226.7983870967755, 233, 71883, 4560.5, 6222.599999999999, 6615.749999999999, 25963.589999999334, 1.2040471520400833, 0.2039491411453984, 0.8324857262152137], "isController": false}, {"data": ["Delete Language", 372, 1, 0.26881720430107525, 5228.481182795699, 14, 134870, 198.0, 2671.0, 17908.64999999918, 124908.67999999979, 1.2813976879727738, 0.24871214365432576, 0.7495305901404715], "isController": false}, {"data": ["SignIn", 500, 128, 25.6, 112761.14999999992, 1426, 148590, 131576.0, 145540.5, 146481.75, 147868.87, 3.277979191388093, 2.877143798391168, 0.9757878213239103], "isController": false}, {"data": ["Update Language", 372, 0, 0.0, 44288.92473118278, 44, 136957, 802.0, 134825.7, 135285.35, 136422.0, 1.2848453868179008, 0.26980107130891895, 0.8055007281222261], "isController": false}, {"data": ["Delete Certification", 372, 0, 0.0, 8666.217741935483, 36, 134588, 1187.5, 2488.6, 87698.34999999971, 133398.32, 1.1996594515105388, 0.2435391072453626, 0.8247658729134955], "isController": false}, {"data": ["Enable ManageListing", 372, 0, 0.0, 1538.7580645161293, 113, 7435, 275.0, 7073.0, 7129.799999999997, 7249.129999999996, 1.140093598006675, 0.2115408043176448, 0.6479828848045751], "isController": false}, {"data": ["Delete Skill", 372, 0, 0.0, 785.0053763440866, 2, 67123, 21.5, 336.59999999999957, 585.0, 35819.56999999934, 1.2718253086398648, 0.3341025468985583, 0.6855933304386772], "isController": false}, {"data": ["Update Skill", 372, 0, 0.0, 3034.6854838709687, 39, 133765, 457.0, 1747.4, 1945.1, 132829.61, 1.27176443640665, 0.322908938931376, 0.793610815296728], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["Non HTTP response code: org.apache.http.NoHttpResponseException/Non HTTP response message: localhost:60968 failed to respond", 128, 92.7536231884058, 1.6913319238900635], "isController": false}, {"data": ["500/Internal Server Error", 10, 7.246376811594203, 0.1321353065539112], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 7568, 138, "Non HTTP response code: org.apache.http.NoHttpResponseException/Non HTTP response message: localhost:60968 failed to respond", 128, "500/Internal Server Error", 10, "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certification", 372, 9, "500/Internal Server Error", 9, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["Delete Language", 372, 1, "500/Internal Server Error", 1, "", "", "", "", "", "", "", ""], "isController": false}, {"data": ["SignIn", 500, 128, "Non HTTP response code: org.apache.http.NoHttpResponseException/Non HTTP response message: localhost:60968 failed to respond", 128, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
