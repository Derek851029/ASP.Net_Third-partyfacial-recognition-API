/*! modernizr 3.3.1 (Custom Build) | MIT *
 * https://modernizr.com/download/?-cssanimations-csspointerevents-csstransforms-csstransforms3d-csstransitions-datalistelem-details-flexbox-matchmedia-picture-mq-setclasses !*/
!function(e,t,n){function r(e,t){return typeof e===t}function i(){var e,t,n,i,s,o,a;for(var u in C)if(C.hasOwnProperty(u)){if(e=[],t=C[u],t.name&&(e.push(t.name.toLowerCase()),t.options&&t.options.aliases&&t.options.aliases.length))for(n=0;n<t.options.aliases.length;n++)e.push(t.options.aliases[n].toLowerCase());for(i=r(t.fn,"function")?t.fn():t.fn,s=0;s<e.length;s++)o=e[s],a=o.split("."),1===a.length?Modernizr[a[0]]=i:(!Modernizr[a[0]]||Modernizr[a[0]]instanceof Boolean||(Modernizr[a[0]]=new Boolean(Modernizr[a[0]])),Modernizr[a[0]][a[1]]=i),y.push((i?"":"no-")+a.join("-"))}}function s(e){var t=S.className,n=Modernizr._config.classPrefix||"";if(w&&(t=t.baseVal),Modernizr._config.enableJSClass){var r=new RegExp("(^|\\s)"+n+"no-js(\\s|$)");t=t.replace(r,"$1"+n+"js$2")}Modernizr._config.enableClasses&&(t+=" "+n+e.join(" "+n),w?S.className.baseVal=t:S.className=t)}function o(){return"function"!=typeof t.createElement?t.createElement(arguments[0]):w?t.createElementNS.call(t,"http://www.w3.org/2000/svg",arguments[0]):t.createElement.apply(t,arguments)}function a(){var e=t.body;return e||(e=o(w?"svg":"body"),e.fake=!0),e}function u(e,n,r,i){var s,u,l,f,d="modernizr",p=o("div"),c=a();if(parseInt(r,10))for(;r--;)l=o("div"),l.id=i?i[r]:d+(r+1),p.appendChild(l);return s=o("style"),s.type="text/css",s.id="s"+d,(c.fake?c:p).appendChild(s),c.appendChild(p),s.styleSheet?s.styleSheet.cssText=e:s.appendChild(t.createTextNode(e)),p.id=d,c.fake&&(c.style.background="",c.style.overflow="hidden",f=S.style.overflow,S.style.overflow="hidden",S.appendChild(c)),u=n(p,e),c.fake?(c.parentNode.removeChild(c),S.style.overflow=f,S.offsetHeight):p.parentNode.removeChild(p),!!u}function l(e){return e.replace(/([a-z])-([a-z])/g,function(e,t,n){return t+n.toUpperCase()}).replace(/^-/,"")}function f(e,t){return!!~(""+e).indexOf(t)}function d(e,t){return function(){return e.apply(t,arguments)}}function p(e,t,n){var i;for(var s in e)if(e[s]in t)return n===!1?e[s]:(i=t[e[s]],r(i,"function")?d(i,n||t):i);return!1}function c(e){return e.replace(/([A-Z])/g,function(e,t){return"-"+t.toLowerCase()}).replace(/^ms-/,"-ms-")}function m(t,r){var i=t.length;if("CSS"in e&&"supports"in e.CSS){for(;i--;)if(e.CSS.supports(c(t[i]),r))return!0;return!1}if("CSSSupportsRule"in e){for(var s=[];i--;)s.push("("+c(t[i])+":"+r+")");return s=s.join(" or "),u("@supports ("+s+") { #modernizr { position: absolute; } }",function(e){return"absolute"==getComputedStyle(e,null).position})}return n}function v(e,t,i,s){function a(){d&&(delete q.style,delete q.modElem)}if(s=r(s,"undefined")?!1:s,!r(i,"undefined")){var u=m(e,i);if(!r(u,"undefined"))return u}for(var d,p,c,v,h,g=["modernizr","tspan","samp"];!q.style&&g.length;)d=!0,q.modElem=o(g.shift()),q.style=q.modElem.style;for(c=e.length,p=0;c>p;p++)if(v=e[p],h=q.style[v],f(v,"-")&&(v=l(v)),q.style[v]!==n){if(s||r(i,"undefined"))return a(),"pfx"==t?v:!0;try{q.style[v]=i}catch(y){}if(q.style[v]!=h)return a(),"pfx"==t?v:!0}return a(),!1}function h(e,t,n,i,s){var o=e.charAt(0).toUpperCase()+e.slice(1),a=(e+" "+k.join(o+" ")+o).split(" ");return r(t,"string")||r(t,"undefined")?v(a,t,i,s):(a=(e+" "+A.join(o+" ")+o).split(" "),p(a,t,n))}function g(e,t,r){return h(e,n,n,t,r)}var y=[],C=[],x={_version:"3.3.1",_config:{classPrefix:"",enableClasses:!0,enableJSClass:!0,usePrefixes:!0},_q:[],on:function(e,t){var n=this;setTimeout(function(){t(n[e])},0)},addTest:function(e,t,n){C.push({name:e,fn:t,options:n})},addAsyncTest:function(e){C.push({name:null,fn:e})}},Modernizr=function(){};Modernizr.prototype=x,Modernizr=new Modernizr,Modernizr.addTest("picture","HTMLPictureElement"in e);var S=t.documentElement,w="svg"===S.nodeName.toLowerCase();Modernizr.addTest("csspointerevents",function(){var e=o("a").style;return e.cssText="pointer-events:auto","auto"===e.pointerEvents});var T="CSS"in e&&"supports"in e.CSS,_="supportsCSS"in e;Modernizr.addTest("supports",T||_);var b=function(){var t=e.matchMedia||e.msMatchMedia;return t?function(e){var n=t(e);return n&&n.matches||!1}:function(t){var n=!1;return u("@media "+t+" { #modernizr { position: absolute; } }",function(t){n="absolute"==(e.getComputedStyle?e.getComputedStyle(t,null):t.currentStyle).position}),n}}();x.mq=b;var E=x.testStyles=u;Modernizr.addTest("details",function(){var e,t=o("details");return"open"in t?(E("#modernizr details{display:block}",function(n){n.appendChild(t),t.innerHTML="<summary>a</summary>b",e=t.offsetHeight,t.open=!0,e=e!=t.offsetHeight}),e):!1});var z=o("input"),P="autocomplete autofocus list placeholder max min multiple pattern required step".split(" "),L={};Modernizr.input=function(t){for(var n=0,r=t.length;r>n;n++)L[t[n]]=!!(t[n]in z);return L.list&&(L.list=!(!o("datalist")||!e.HTMLDataListElement)),L}(P),Modernizr.addTest("datalistelem",Modernizr.input.list);var N="Moz O ms Webkit",k=x._config.usePrefixes?N.split(" "):[];x._cssomPrefixes=k;var M=function(t){var r,i=prefixes.length,s=e.CSSRule;if("undefined"==typeof s)return n;if(!t)return!1;if(t=t.replace(/^@/,""),r=t.replace(/-/g,"_").toUpperCase()+"_RULE",r in s)return"@"+t;for(var o=0;i>o;o++){var a=prefixes[o],u=a.toUpperCase()+"_"+r;if(u in s)return"@-"+a.toLowerCase()+"-"+t}return!1};x.atRule=M;var A=x._config.usePrefixes?N.toLowerCase().split(" "):[];x._domPrefixes=A;var j={elem:o("modernizr")};Modernizr._q.push(function(){delete j.elem});var q={style:j.elem.style};Modernizr._q.unshift(function(){delete q.style}),x.testAllProps=h,x.testAllProps=g,Modernizr.addTest("cssanimations",g("animationName","a",!0)),Modernizr.addTest("flexbox",g("flexBasis","1px",!0)),Modernizr.addTest("csstransforms",function(){return-1===navigator.userAgent.indexOf("Android 2.")&&g("transform","scale(1)",!0)}),Modernizr.addTest("csstransforms3d",function(){var e=!!g("perspective","1px",!0),t=Modernizr._config.usePrefixes;if(e&&(!t||"webkitPerspective"in S.style)){var n,r="#modernizr{width:0;height:0}";Modernizr.supports?n="@supports (perspective: 1px)":(n="@media (transform-3d)",t&&(n+=",(-webkit-transform-3d)")),n+="{#modernizr{width:7px;height:18px;margin:0;padding:0;border:0}}",E(r+n,function(t){e=7===t.offsetWidth&&18===t.offsetHeight})}return e}),Modernizr.addTest("csstransitions",g("transition","all",!0));var H=x.prefixed=function(e,t,n){return 0===e.indexOf("@")?M(e):(-1!=e.indexOf("-")&&(e=l(e)),t?h(e,t,n):h(e,"pfx"))};Modernizr.addTest("matchmedia",!!H("matchMedia",e)),i(),s(y),delete x.addTest,delete x.addAsyncTest;for(var O=0;O<Modernizr._q.length;O++)Modernizr._q[O]();e.Modernizr=Modernizr}(window,document);