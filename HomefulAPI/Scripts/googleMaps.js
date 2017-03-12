var defaultPosition = { lat: 36.1627, lng: -86.7816 };
var map;
const LOCATIONS_ENDPOINT = 'http://homefulapi.azurewebsites.net/api/locations';
//var getLocations = '/api/locations';


function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 11,
        center: defaultPosition
    });

    function createMarker(location, map) {
        var marker = new google.maps.Marker({
            position: { lat: 36.1637, lng: -86.79 },
            //position: { lat: location.Latitude, lng: location.Lsongitude },
            map: map
        });
    }

    $.ajax({
        dataType: "json",
        url: LOCATIONS_ENDPOINT,
        success: function (locations) {
            //locations.map(createMarker, map);
        }
    });
}

function removeLocation(location, marker) {
    marker.setMap(null);
    // TODO - make call to server to delete
}

function createInfowindow(map, marker, location) {
    // TODO - fill in the content string with actual data from the location
    // TODO - make the data editable (edit a location)
    // TODO - add a delete/remove button in the infowindow
    var contentString =
        '<div id="content">' +
        '<div id="siteNotice">' +
        '</div>' +
        '<h1 id="firstHeading" class="firstHeading">Uluru</h1>' +
        '<div id="bodyContent">' +
        '<p><b>Uluru</b>, also referred to as <b>Ayers Rock</b>, is a large ' +
        'sandstone rock formation in the southern part of the ' +
        'Northern Territory, central Australia. It lies 335&#160;km (208&#160;mi) ' +
        'south west of the nearest large town, Alice Springs; 450&#160;km ' +
        '(280&#160;mi) by road. Kata Tjuta and Uluru are the two major ' +
        'features of the Uluru - Kata Tjuta National Park. Uluru is ' +
        'sacred to the Pitjantjatjara and Yankunytjatjara, the ' +
        'Aboriginal people of the area. It has many springs, waterholes, ' +
        'rock caves and ancient paintings. Uluru is listed as a World ' +
        'Heritage Site.</p>' +
        '<p>Attribution: Uluru, <a href="https://en.wikipedia.org/w/index.php?title=Uluru&oldid=297882194">' +
        'https://en.wikipedia.org/w/index.php?title=Uluru</a> ' +
        '(last visited June 22, 2009).</p>' +
        '</div>' +
        '</div>';

    var infowindow = new google.maps.InfoWindow({
        content: contentString
    });
}

function createLocation() {
    // Place a draggable marker on the map
    var newLocation = {
        name: '',
        latitude: defaultPosition.lat,
        longitude: defaultPosition.lng,
        notes: ''
    };
    var newMarker = new google.maps.Marker({
        position: defaultPosition,
        map: map,
        animation: google.maps.Animation.DROP,
        draggable: true,
        title: "Drag me!"
    });
    newMarker.addListener('mouseup', function (marker) {
        newLocation.latitude = newMarker.position.lat;
        newLocation.longitude = newMarker.position.lng;
        // TODO - make this a PUT - too tired to think of how it should save
        /*$.post({
            url: LOCATIONS_ENDPOINT + '/' + newLocation.id,
            data: newLocation,
            success: function (location) {

            }
        });*/
    });
    
    newMarker.addListener('click', function (marker) {
        createInfowindow(map, marker, newLocation);
    });
}