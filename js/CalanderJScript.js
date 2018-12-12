var textboxname


function positionInfo(object) {
    var p_elm = object
    this.getElementLeft = getElementLeft
    function getElementLeft() {
        var x = 0
        var elm
        if (typeof (p_elm) == "object") {
            elm = p_elm
        }
        else {
            elm = document.getElementById(p_elm)
        }
        while (elm != null) {
            x += elm.offsetLeft
            elm = elm.offsetParent
        }
        return parseInt(x)
    }
    this.getElementWidth = getElementWidth
    function getElementWidth() {
        var elm
        if (typeof (p_elm) == "object") {
            elm = p_elm
        }
        else {
            elm = document.getElementById(p_elm)
        }
        return parseInt(elm.offsetWidth)
    }
    this.getElementRight = getElementRight
    function getElementRight() {
        return getElementLeft(p_elm) + getElementWidth(p_elm)
    }
    this.getElementTop = getElementTop
    function getElementTop() {
        var y = 0
        var elm
        if (typeof (p_elm) == "object") {
            elm = p_elm
        }
        else {
            elm = document.getElementById(p_elm)
        }
        while (elm != null) {
            y += elm.offsetTop
            elm = elm.offsetParent
        }
        return parseInt(y)
    }
    this.getElementHeight = getElementHeight
    function getElementHeight() {
        var elm
        if (typeof (p_elm) == "object") {
            elm = p_elm
        }
        else {
            elm = document.getElementById(p_elm)
        }
        return parseInt(elm.offsetHeight)
    }
    this.getElementBottom = getElementBottom
    function getElementBottom() {
        return getElementTop(p_elm) + getElementHeight(p_elm)
    }
}
function CalendarControl() {
    var calendarId = 'CalendarControl'
    var currentYear = 0
    var currentMonth = 0
    var currentDay = 0
    var selectedYear = 0
    var selectedMonth = 0
    var Type = ''
    var selectedDay = 0
    var months = ['Jan','Feb', 'Mar', 'Apr', 'May', 'June', 'July', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec']
    var dateField = null
    function getProperty(p_property) {
        var p_elm = calendarId
        var elm = null
        if (typeof (p_elm) == "object") {
            elm = p_elm
        }
        else {
            elm = document.getElementById(p_elm)
        }
        if (elm != null) {
            if (elm.style) {
                elm = elm.style
                if (elm[p_property]) {
                    return elm[p_property]
                }
                else {
                    return null
                }
            }
            else {
                return null
            }
        }
    }
    function setElementProperty(p_property, p_value, p_elmId) {
        var p_elm = p_elmId
        var elm = null
        if (typeof (p_elm) == "object") {
            elm = p_elm
        }
        else {
            elm = document.getElementById(p_elm)
        }
        if ((elm != null) && (elm.style != null)) {
            elm = elm.style
            elm[p_property] = p_value
        }
    }
    function setProperty(p_property, p_value) {
        setElementProperty(p_property, p_value, calendarId)
    }
    function getDaysInMonth(year, month) {
        return [31, ((!(year % 4) && ((year % 100) || !(year % 400))) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][month - 1]
    }
    function getDayOfWeek(year, month, day) {
        var date = new Date(year, month - 1, day)
        return date.getDay()
    }
    this.clearDate = clearDate
    function clearDate() {
        dateField.value = ''
        hide()
    }
    this.setDate = setDate
    function setDate(year, month, day, type) {
        if (dateField) {
            if (day < 10) { day = "0" + day; }
            // var dateString = day + "-" + months[month - 1] + "-" + year

            var dateString = year + "-" + months[month - 1] + "-" + day
            dateField.value = dateString
            hide()
        }
        return
    }
    this.changeMonth = changeMonth
    function changeMonth(change) {
        currentMonth = change
        calendar = document.getElementById(calendarId)
        calendar.innerHTML = calendarDrawTable()
    }
    this.changeYear = changeYear
    function changeYear(change) {
        currentYear = change
        currentDay = 0
        calendar = document.getElementById(calendarId)
        calendar.innerHTML = calendarDrawTable()
    }
    function getCurrentYear() {
        var year = new Date().getYear()
        if (year < 1900) year += 1900
        return year
    }
    function getCurrentMonth() {
        return new Date().getMonth() + 1
    }
    function getCurrentDay() {
        return new Date().getDate()
    }
    function calendarDrawTable() {
        var dayOfMonth = 1
        var validDay = 0
        var startDayOfWeek = getDayOfWeek(currentYear, currentMonth, dayOfMonth)
        var daysInMonth = getDaysInMonth(currentYear, currentMonth)
        var css_class = null
        //var timelineInterval = 0;
        var currentTime = new Date()
        var currentYr = (currentTime.getFullYear())
        var table = "<table id='fc' cellspacing='0' cellpadding='0' border='0' >"
        table = table + "<tr class='header'>"
        table = table + "  <td colspan='7' class='previous'><select name='ddlMonths' class='ddl' onchange='javascript:changeCalendarControlMonth(this.options[this.selectedIndex].value);'>"
        for (i = 0; i < months.length; i++) {
            if (i == (currentMonth - 1)) {
                table = table + "<option value=\"" + (i + 1) + "\" selected=\"selected\">" + months[i] + "</option>"
            }
            else {
                table = table + "<option value=\"" + (i + 1) + "\">" + months[i] + "</option>"
            }
        }
        table = table + "</select>"
        table = table + "<select name='ddlYears' class='ddl' onchange='javascript:changeCalendarControlYear(this.options[this.selectedIndex].value);'>"
        if (Type == 'DOB') {//set Min years
            for (i = (currentYr - 60) ; i <= (currentYr - 18) ; i++) {
                if (i == currentYear) {
                    table = table + "<option value=\"" + i + "\" selected=\"selected\">" + i + "</option>"
                }
                else {
                    table = table + "<option value=\"" + (i) + "\">" + i + "</option>"
                }
            }
        }
        else {
            for (i = (currentYr - 45) ; i <= (currentYr + 10) ; i++) {
                if (i == currentYear) {
                    table = table + "<option value=\"" + i + "\" selected=\"selected\">" + i + "</option>"
                }
                else {
                    table = table + "<option value=\"" + (i) + "\">" + i + "</option>"
                }
            }
        }
        table = table + "</select></td>"
        table = table + "</tr>"
        table = table + "<tr><th>S</th><th>M</th><th>T</th><th>W</th><th>T</th><th>F</th><th>S</th></tr>"
        for (var week = 0; week < 6; week++) {
            table = table + "<tr>"
            for (var dayOfWeek = 0; dayOfWeek < 7; dayOfWeek++) {
                if (week == 0 && startDayOfWeek == dayOfWeek) {
                    validDay = 1
                }
                else if (validDay == 1 && dayOfMonth > daysInMonth) {
                    validDay = 0
                }
                if (validDay) {
                    if (dayOfMonth == selectedDay && currentYear == selectedYear && currentMonth == selectedMonth) {
                        css_class = 'current'
                    }
                    else if (dayOfWeek == 0 || dayOfWeek == 6) {
                        css_class = 'weekend'
                    }
                    else {
                        css_class = 'weekday'
                    }
                    table = table + "<td><a class='" + css_class + "' href=\"javascript:setCalendarControlDate(" + currentYear + "," + currentMonth + "," + dayOfMonth + ")\">" + dayOfMonth + "</a></td>"
                    dayOfMonth++
                }
                else {
                    table = table + "<td class='empty'>&nbsp;</td>"
                }
            }
            table = table + "</tr>"
        }
        table = table + "<tr class='header'><th colspan='7' style='padding: 3px;'><a href='javascript:clearCalendarControl();'>Clear</a> | <a href='javascript:hideCalendarControl();'>Close</a></td></tr>"
        table = table + "</table>"
        return table
    }
    this.show = show
    function show(field, Type1) {
        //debugger;
        Type = Type1
        can_hide = 0
        if (dateField == field) {
            return
        }
        else {
            dateField = field
        }
        if (dateField) {
            try {
                textboxname = dateField.name
                var Obj = document.getElementById(textboxname)
                var dateString = new String(dateField.value)
                var dateParts = dateString.split("-")
                for (i = 0; i < months.length; i++) {
                    if (months[i] == dateParts[1]) {
                        selectedMonth = i + 1
                    }
                }
                selectedDay = parseInt(dateParts[0], 10)
                selectedYear = parseInt(dateParts[2], 10)
            }
            catch (e) { }
        }
        if (!(selectedYear && selectedMonth && selectedDay)) {
            selectedMonth = getCurrentMonth()
            selectedDay = getCurrentDay()
            if (Type == 'DOB')//
                selectedYear = getCurrentYear() - 25;
            else
                selectedYear = getCurrentYear()
        }
        currentMonth = selectedMonth
        currentDay = selectedDay
        currentYear = selectedYear
        if (document.getElementById) {
            calendar = document.getElementById(calendarId)
            calendar.innerHTML = calendarDrawTable(currentYear, currentMonth)
            setProperty('display', 'block')
            var fieldPos = new positionInfo(dateField)
            var calendarPos = new positionInfo(calendarId)
            var x = fieldPos.getElementLeft()
            var y = fieldPos.getElementBottom()
            setProperty('left', x + "px")
            setProperty('top', y + "px")
            if (document.all) {
                setElementProperty('display', 'block', 'CalendarControlIFrame')
                setElementProperty('left', x + "px", 'CalendarControlIFrame')
                setElementProperty('top', y + "px", 'CalendarControlIFrame')
                setElementProperty('width', calendarPos.getElementWidth() + "px", 'CalendarControlIFrame')
                setElementProperty('height', calendarPos.getElementHeight() + "px", 'CalendarControlIFrame')
            }
        }
    }
    this.hide = hide
    function hide() {
        if (dateField) {
            setProperty('display', 'none')
            setElementProperty('display', 'none', 'CalendarControlIFrame')
            dateField = null
        }
    }
    this.visible = visible
    function visible() {
        return dateField
    }
    this.can_hide = can_hide
    var can_hide = 0
}
var calendarControl = new CalendarControl()
function showCalendarControl(textField, Type) {
    calendarControl.show(textField, Type)
}
function clearCalendarControl() {
    calendarControl.clearDate()
}
function hideCalendarControl() {
    if (calendarControl.visible()) {
        calendarControl.hide()
    }
}
function setCalendarControlDate(year, month, day) {
    calendarControl.setDate(year, month, day)
}
function changeCalendarControlYear(change) {
    calendarControl.changeYear(change)
}
function changeCalendarControlMonth(change) {
    calendarControl.changeMonth(change)
}
document.write("<iframe id='CalendarControlIFrame'  src='javascript:false;' frameBorder='0' scrolling='no'></iframe>")
document.write("<div id='CalendarControl' ></div>")
document.all ? document.attachEvent('onclick', checkClick) : document.addEventListener('click', checkClick, false)
function changeCalendarControlMonth1(change) {
    calendarControl.changeMonth(change)
}
function checkClick(e) {
    e ? evt = e : evt = event
    CSE = evt.target ? evt.target : evt.srcElement
    if (getObj('fc') != null) {
        if (isChild(CSE, getObj('fc'))) { }
        else {
            if (CSE.id.replace(/_/g, "$") != textboxname)
                hideCalendarControl()
        }
    }
}
function getObj(objID) {
    if (document.getElementById) {
        return document.getElementById(objID);
    }
    else if (document.all) { return document.all[objID]; }
    else if (document.layers) { return document.layers[objID]; }
}
function isChild(s, d) {
    while (s) {
        if (s == d)
            return true
        s = s.parentNode
    }
    return false
}
function Validation(e) {
    var keyCode
    if (window.event)
        keyCode = event.keyCode
    else if (e.which)
        keyCode = e.which
    if (keyCode == 9) {
        hideCalendarControl()
    }
    else {
        return false
    }
}