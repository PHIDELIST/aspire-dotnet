import React, { useState, useEffect } from 'react';
import logo from './logo.svg';
import './App.css';

function App() {
  const [data, setData] = useState(null);
  const [name, setName] = useState('');
  const [bio, setBio] = useState('');
  const [error, setError] = useState(null);
  const [isLoading, setIsLoading] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('https://localhost:7538/api/delphit/whoisdelphi');
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        const jsonData = await response.json();
        setData(jsonData[0]);
      } catch (error) {
        setError(error.message);
      }
    };

    fetchData();
  }, []);

  const handleNameChange = (event) => {
    setName(event.target.value);
  };

  const handleBioChange = (event) => {
    setBio(event.target.value);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    setIsLoading(true);

    try {
      const response = await fetch('https://localhost:7538/api/delphit/add', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({ id: data.id, name: name, bio: bio }),
      });

      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      
      // Update the data state with the updated name and bio
      setData({ ...data, name: name, bio: bio });
      alert('Item saved');
    } catch (error) {
      setError(error.message);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
      <p>
          {error && <span>Error: {error}</span>}
          {data ? (
            <div>
              <p>Name: {data.name}</p>
              <p>Bio: {data.bio}</p>
            </div>
          ) : (
            <span>Loading...</span>
          )}
        </p>
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          {error && <span>Error: {error}</span>}
          {isLoading && <span>Loading...</span>}
          {data && (
            <form onSubmit={handleSubmit}>
              <div>
                <label>Name:</label>
                <input type="text" value={name} onChange={handleNameChange} />
              </div>
              <div>
                <label>Bio:</label>
                <textarea value={bio} onChange={handleBioChange} />
              </div>
              <button type="submit">Save</button>
            </form>
          )}
        </p>
      </header>
    </div>
  );
}

export default App;
