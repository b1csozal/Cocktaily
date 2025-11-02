import { useEffect, useState } from 'react';
import { SafeAreaView } from 'react-native-safe-area-context';
import {
  Text,
  StyleSheet,
  Button,
  Image,
  Dimensions,
  View,
  TouchableOpacity,
  TextInput,
  Keyboard,
} from 'react-native';
import * as ImagePicker from 'expo-image-picker';
import { Svg, Path } from 'react-native-svg';
import React from 'react';
import apiClient from '../../services/apiClient';

const screenWidth = Math.round(Dimensions.get('window').width);

const TabsAdd = () => {
  const [isGlassesDropdownOpen, setIsGlassesDropdownOpen] = useState(false);

  const [image, setImage] = useState<string | null>(null);
  const [cocktailName, setCocktailName] = useState<string>('Koktél');

  const [glasses, setGlasses] = useState([]);

  useEffect(() => {
    // Fetch glass types from the API
    const fetchGlasses = async () => {
      try {
        apiClient.get('/all-glasses').then((response) => {
          alert(JSON.stringify(response.data));
          setGlasses(response.data);
        });
      } catch (error) {
        alert('Error fetching glasses: ' + error);
        console.error('Error fetching glasses:', error);
      }
    };

    fetchGlasses();
  }, []);

  const pickImage = async () => {
    // No permissions request is necessary for launching the image library
    let result = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ['images'],
      allowsEditing: true,
      aspect: [1, 1],
      quality: 1,
    });

    console.log(result);

    if (!result.canceled) {
      setImage(result.assets[0].uri);
    }
  };

  return (
    <SafeAreaView style={styles.container}>
      <TouchableOpacity onPress={Keyboard.dismiss} activeOpacity={1} />
      {image ? (
        <>
          <Image source={{ uri: image }} style={styles.image} />
          <TouchableOpacity style={styles.deleteImageButton} onPress={() => setImage(null)}>
            <Svg width="36" height="36" fill={styles.deleteImageButton.color} viewBox="0 0 24 24">
              <Path d="M5.293 5.293a1 1 0 0 1 1.414 0L12 10.586l5.293-5.293a1 1 0 1 1 1.414 1.414L13.414 12l5.293 5.293a1 1 0 0 1-1.414 1.414L12 13.414l-5.293 5.293a1 1 0 0 1-1.414-1.414L10.586 12 5.293 6.707a1 1 0 0 1 0-1.414Z"></Path>
            </Svg>
          </TouchableOpacity>
        </>
      ) : (
        <TouchableOpacity style={styles.placeholder} onPress={() => pickImage()} activeOpacity={1}>
          <Svg width="46" height="46" fill={styles.placeholderImage.color} viewBox="0 0 24 24">
            <Path d="M15.5 10a1.5 1.5 0 1 0 0-3 1.5 1.5 0 0 0 0 3Z"></Path>
            <Path d="M3 5a2 2 0 0 1 2-2h14a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5Zm16 0H5v7.92l3.375-2.7a1 1 0 0 1 1.25 0l4.3 3.44 1.368-1.367a1 1 0 0 1 1.414 0L19 14.586V5ZM5 19h14v-1.586l-3-3-1.293 1.293a1 1 0 0 1-1.332.074L9 12.28l-4 3.2V19Z"></Path>
          </Svg>
        </TouchableOpacity>
      )}

      <TextInput
        style={styles.title}
        placeholder="Koktél neve"
        value={cocktailName}
        onChangeText={setCocktailName}
      />

      
    </SafeAreaView>
  );
};

const styles = StyleSheet.create({
  container: {
    paddingHorizontal: 10,
    paddingTop: screenWidth - 140,
  },
  image: {
    position: 'absolute',
    top: 0,
    width: screenWidth,
    height: screenWidth - 100,
    resizeMode: 'cover',
    borderBottomLeftRadius: 20,
    borderBottomRightRadius: 20,
  },
  placeholder: {
    position: 'absolute',
    top: 0,
    width: screenWidth,
    height: screenWidth - 100,
    backgroundColor: '#e0e0e0',
    borderBottomLeftRadius: 20,
    borderBottomRightRadius: 20,
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  placeholderImage: {
    color: '#9e9e9e',
  },
  deleteImageButton: {
    position: 'absolute',
    top: 40,
    right: 20,
    color: '#e20e0eff',
  },
  title: {
    fontSize: 42,
    fontWeight: 'bold',
  },
});

export default TabsAdd;
