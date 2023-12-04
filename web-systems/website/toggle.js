
	    function toggleCSS() {
          // Obtains the <link> element that links to the css (by using its id).
          var currentCSS = document.getElementById('stylesheet-link');

          // Change the value of href attribute to change the css file.
          if (currentCSS.getAttribute('href') == 'main.css') {
            currentCSS.setAttribute('href', 'alternate.css');
          } else {
            currentCSS.setAttribute('href', 'main.css');
          }

      }
