var defaultPosition = { lat: 36.1627, lng: -86.7816 };
var map;
var selectedLocation;
var selectedMarker;
const LOCATIONS_ENDPOINT = 'http://homefulapi.azurewebsites.net/api/locations';
//var getLocations = '/api/locations';

function pinSymbol(color) {
    return {
        path: 'M 0,0 C -2,-20 -10,-22 -10,-30 A 10,10 0 1,1 10,-30 C 10,-22 2,-20 0,0 z M -2,-30 a 2,2 0 1,1 4,0 2,2 0 1,1 -4,0',
        fillColor: color,
        fillOpacity: 1,
        strokeColor: '#000',
        strokeWeight: 2,
        scale: 1,
    };
}
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 13,
        center: defaultPosition
    });

    function createMarker(location) {
        var newMarker = new google.maps.Marker({
            position: { lat: location.Latitude, lng: location.Longitude },
            map: map,
            animation: google.maps.Animation.DROP,
            draggable: true,
            title: location.Name
        });

        addMarkerMouseup(location, newMarker);
        addMarkerClick(newMarker, location);
    }

    $.ajax({
        dataType: "json",
        url: LOCATIONS_ENDPOINT,
        success: function (locations) {
            locations.map(createMarker);
        }
    });
}

function removeLocation() {
    selectedMarker.setMap(null);
    $.ajax({
        method: 'DELETE',
        url: LOCATIONS_ENDPOINT + '/' + selectedLocation.Id,
        data: selectedLocation,
        success: function (l) {
        }
    });

    // TODO - make call to server to delete
}

function addMarkerClick(marker, location) {
    // TODO - fill in the content string with actual data from the location
    // TODO - make the data editable (edit a location)
    // TODO - add a delete/remove button in the infowindow
    
    var infowindow = new google.maps.InfoWindow({
        content: '<div class="row">' +
                '<div class="col s12">' +
                '<div class="row">' +
                '<div class="input-field col s12">' +
                    '<label for="name" class="active">Name</label>' + 
                    '<input type="text" name="name" class="validate" value="' + location.Name + '"/>' +
                '</div>' +
                '</div>' +
                '</div>' +
        '</div>' + '<a class="waves-effect waves-light btn left" onclick="updateSelectedLocation()">Save</a>' +
        '<a class="waves-effect waves-light btn right" onclick="removeLocation()">Delete</a>'

    });
    
    marker.addListener('click', function () {
        selectedLocation = location;
        selectedMarker = marker;
        infowindow.open(map, marker);
    });
}
function addMarkerMouseup(location, marker) {
    marker.addListener('mouseup', function (m) {
        location.Latitude = marker.position.lat;
        location.Longitude = marker.position.lng;
        $.ajax({
            method: 'PUT',
            url: LOCATIONS_ENDPOINT + '/' + location.Id,
            data: location,
            success: function (l) {
                location = l;
            }
        });
    });
}
function updateSelectedLocation() {
    $.ajax({
        method: 'PUT',
        url: LOCATIONS_ENDPOINT + '/' + selectedLocation.Id,
        data: selectedLocation,
        success: function (l) {
            selectedLocation = l;
        }
    });
}
function createLocation() {
    // Place a draggable marker on the map
    var newLocation = {
        name: 'New Camp',
        latitude: defaultPosition.lat,
        longitude: defaultPosition.lng,
        notes: ''
    };
    var newMarker = new google.maps.Marker({
        position: defaultPosition,
        map: map,
        icon: pinSymbol('lightblue'),
        animation: google.maps.Animation.DROP,
        draggable: true,
        title: 'Drag me!'
    });
    $.ajax({
        method: 'POST',
        url: LOCATIONS_ENDPOINT,
        data: newLocation,
        success: function (location) {
            newLocation = location;
            console.log('created location');
            console.log(newLocation);
            addMarkerMouseup(newLocation, newMarker);
            addMarkerClick(newMarker, newLocation);
        }
    });
    
}