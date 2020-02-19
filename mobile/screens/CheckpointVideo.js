import React, { useState, useEffect, } from 'react';
import { StyleSheet, Text, TouchableOpacity, View, ScrollView, Image } from 'react-native';
import { WebView } from 'react-native-webview';
import { GetUserSettings, SetUserSettings } from '../Services/UserController';
import { simpleAlertCallback } from '../utils/Alerts';
import DefaultButton from '../components/DefaultButton';
import Api from '../Services/Api';


export default function CheckpointVideo({ route, navigation }) {

  navigation.setOptions({ headerTitle: 'Video' });

  const [videoState, setvideoState] = useState({ paragraphs: [] });
  const [user, setUser] = useState({});

  useEffect(() => {
    async function setUserAsync() {
      var user = await GetUserSettings();
      setUser(user);
    };
    setUserAsync();
  }, []);

  useEffect(() => {
    async function getQuizData() {
      var { trailID } = route.params;
      await Api.get(`/youtubeTrail/${trailID}`)
        .then(function (response) {
          var _resp = JSON.parse(response.request._response);
          var paragraphs = _resp.paragraphs;
          _resp.paragraphs = paragraphs.split(';');
          setvideoState(_resp);
        }.bind(this))
        .catch(function (error) {
          console.log(error);
        }.bind(this))
        .finally(function () {
        }.bind(this));
    };

    getQuizData();
  }, []);

  function setscrollView(scroll) {
    // scroll.
  };

  async function handleCompleteTrail() {
    var _user = user;
    user.coins += videoState.reward;
    user.trailID += 1;
    setUser(_user);
    await SetUserSettings(_user);

    simpleAlertCallback('Muito bom', 'Parabéns, você adquiriu mais conhecimento rumo a sua independência financeira', () => { navigation.navigate('Root') });
  }


  return (
    <View style={styles.container}>
      <ScrollView
        ref={(scroll) => { setscrollView(scroll) }}
        style={[styles.scrollView, { Height: "auto" }]}
        contentContainerStyle={styles.scrollViewContainer}
      >
        <WebView
          style={styles.videoPlayer}
          javaScriptEnabled={true}
          source={{ uri: videoState.url }}
        />
        <View style={styles.textContent}>
          <Text style={styles.title}>{videoState.title}</Text>
          {
            videoState.paragraphs.map(p => (
              <Text style={styles.paragraph}>{p}</Text>
            ))
          }
          <Text style={styles.productsHeader}>Melhores investimentos</Text>
          <Image style={styles.products} source={require('../assets/images/produtos.png')} />

        </View>
        <DefaultButton enabled={user.trailID <= videoState.id} onClick={handleCompleteTrail} text={"Marcar como visto"} />
      </ScrollView>
    </View>

  );
}


const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    backgroundColor: '#f6f7eb'
  },
  videoPlayer: {
    marginTop: 10,
    height: 230,
    // width: 370
  },
  textContent: {
    padding: 10
  },
  title: {
    fontSize: 22,
    marginBottom: 20,
  },
  paragraph: {
    textAlign: 'justify',
    marginBottom: 10,
    fontSize: 16
  },
  button: {
    alignItems: 'center',
    padding: 15,
    marginTop: 10,
    backgroundColor: '#4d0250',

    marginBottom: 10,
    borderRadius: 3
  },
  buttonText: {
    color: 'white'
  },
  productsHeader: {
    textAlign: 'justify',
    marginBottom: 10,
    marginTop: 10,
    fontSize: 20,
    fontWeight: 'bold'
  },
  products: {
    resizeMode: 'cover',
    width: '90%',
    height: 270,
    alignSelf: 'center'
  }
})

CheckpointVideo.navigationOptions = {
  header: null,
};
