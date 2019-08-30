$(document).ready(function() {
   $("a").click(function() {
		$(this).parents("div.menu_wrapper").find("div.sub_menu").toggle();
	});
}); 

var updateIntervalId;
var quoteUrl;
var quoteParams = "?n=3&q=";

function startUpdateInterval(url) {
	quoteUrl = url;
	buildTicker()
	updateIntervalId = setInterval ("buildTicker()", 18000 );
}

function stopUpdateInterval() {
	clearInterval(updateIntervalId);	
}

function buildTicker() {
	if (iPause ==1)
		return; //don't update whilst someone is hovering
	$.ajax({
     	type: "GET",
        url: (quoteUrl + quoteParams),
        dataType: "html",
        error: function(){
         		$("div#ticker_loading").hide();
				$("div#quotes_panel").hide();
				$("div#reading_links").show();
        },
        success: function(data){
			if(data.indexOf("error") == -1)
			{
				quoteParams = "?n=3&q=";
				var mainArr = data.split(":");
				var newHtml = "<div class=\"tickerbox\"><ul id=\"ticker\">";
				
				for ( var i=0, len=mainArr.length-1; i<len; ++i ){
					
					var arr = mainArr[i].split(",");
					quoteParams = quoteParams + "ASX:" + arr[0] + ",";
					
					if((i+1)%3 == 1)
						newHtml = newHtml + "<li>";
					
					if (newHtml == undefined)
						newHtml = arr[0] + ":&nbsp;" + arr[1] + "&nbsp;&nbsp;";
					else
						newHtml = newHtml + arr[0] + ":&nbsp;" + arr[1] + "&nbsp;&nbsp;";
				
					if (arr[2].indexOf("-") == -1)
						newHtml = newHtml + "<span class=\"quoteGain\">" + arr[2] + "&nbsp;&nbsp;" + arr[3] +"</span>&nbsp;&nbsp;";
					else
						newHtml = newHtml + "<span class=\"quoteLoss\">" + arr[2] + "&nbsp;&nbsp;" + arr[3] + "</span>&nbsp;&nbsp;";
						
					if((i+1)%3 == 0)
						newHtml = newHtml + "</li>";
				}
				
				newHtml = newHtml + "</ul></div>";
				
				$("div#ticker_loading").hide();
				
				if (tickIntervalId != null)
					clearInterval(tickIntervalId);
					
				$("div#quotes_panel").html(newHtml);
				$("div#quotes_panel").show();
				
				$("div#reading_links").hide();
				
				newsitems = null;
				curritem=0;
				startTicking();
			}
			else
			{
				$("div#ticker_loading").hide();
				$("div#quotes_panel").hide();
				$("div#reading_links").show();
			}
      	}
    });	
}

var newsitems;
var curritem=0;
var iPause=0;
var tickIntervalId;

function startTicking() {
	$("#ticker").children().hide();
    var tickerSelector = "ul#ticker li";
    newsitems = $(tickerSelector).hide().hover(
        function(){
            $(this).addClass("hovered");
            iPause=1;
        },
        function(){
            $(this).removeClass("hovered");
            iPause=0;
        }
    ).filter(":eq(0)").show().add(tickerSelector).size();
	
	if (tickIntervalId != null)
		clearInterval(tickIntervalId);
		
    tickIntervalId = setInterval("tick()", 6000); //time in milliseconds
}


function tick() {
	var  liCount = $("#ticker").children().size();
	if (iPause==0 && liCount > 1){
		$("#ticker li:eq("+curritem+")").fadeOut(800, function(){
			$(this).hide();
			curritem = ++curritem%newsitems;
			$("#ticker li:eq("+curritem+")").fadeIn(800);
		});
    }
}
