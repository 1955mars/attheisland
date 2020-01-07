![](/AtTheIsland/Assets/Images/9.JPG "At the Island - VR experience")

# Introduction
   Education has played a major role in human evolution. We became Homo Sapiens, the predominant species of this world, by transferring knowledge among ourselves. Every human civilization has given knowledge transfer the highest priority. We constantly look for ways to make knowledge transfer happen more easily, quickly and effectively.
   
   Before the digital revolution, printed media in the form of books has acted as a powerful tool in enabling access to the information. This information includes facts and observations about the world. With the advent of computers and the internet, answers to many questions are just a few clicks away. Being educated isn't the same as being informed. Having access to and consuming a lot of information isn't learning. Comprehending the information in the right way is crucial for any use of it           
  
  The world information exists mainly in textual and visual forms. With the proliferation of personal computing devices, the generation of visual data has increased in recent times. But still, the majority of it exists in textual form and comprehending this information isn't easy for everyone for evolutionary reasons.
  
  We are all visual learners as our brains process images 60000 times faster than text and 90% of the information transmitted to the brain is visual. Conversion of textual information into visual form puts a great amount of cognitive load on the brain. As a result, learners become bored and get disengaged easily. For an easier comprehension, the content delivery should be in the rich visual form which our current educational system with the existing technologies could do only much. 
  
  Virtual reality can transform the way educational content is delivered today. It works on the premise of creating a visually rich virtual world - real or imagined - and allow users to interact with it. Getting immersed in whatever we are learning motivates us to fully understand it. A physics student enjoys learning quantum mechanics by getting immersed inside an atom rather than staring at the mysterious equations. VR offers infinite possible learning solutions and will become the greatest technology our educational system has ever leveraged.
  
  Some Ed-tech companies have already started developing educational content in VR. As a project work of UDACITY VR nano degree program, I have developed a mobile VR experience called "AT THE ISLAND" showcasing five such Ed-tech companies. This article serves two purposes: 1) Discussing the design and development process I have taken for creating this VR experience which can help the other VR content developers. 2) An opportunity for the first time VR users to learn a new thing using VR and to realize its potential in Education.
  
Below is the video of the  AT THE ISLAND virtual reality experience.

[![Alt text](https://img.youtube.com/vi/395EzivcNhI/0.jpg)](https://youtu.be/395EzivcNhI)

[Download Android apk file from here](https://drive.google.com/file/d/1AlOb4MgVXfcZ4tBx2TMR38aMQhhjWPOs/view)

# The Process

## Statement of Purpose

At The Island is a VR experience showcasing VR Ed-Tech companies with a setting on a dreamy island. The main purpose of this work is to let know the people about how these companies are leveraging VR for providing high-quality education. The targeted audience is anyone who is enthusiastic about VR and especially VR in Education.

## Persona

|Syntax |Description|
|-------|-----------|
|Name |Vishnu      |
|Age |25      |
|Occupation |Graduate Student      |
|VR Experience | No|
    I enjoy teaching high school students. I use technology to provide good learning experiences and outcomes.
    
    
Vishnu is currently pursuing his masters and is interested in becoming an educator after graduation. He loves using digital technology to provide the best learning experiences to his students. He has heard about VR in Education but didn't get an opportunity to explore about it.

## Designs, Sketches & Models

### 1. Virtual World

I wanted to create a dreamy island in an ocean with day/night cycle - sunrise, sunset, stars-  and then let the user explore and learn about the five VR Ed-Tech companies. I came up with different designs for the virtual world and rapidly prototyped them using 3D modeling tools like Blender and Pro builder(now part of Unity3D). Here are my sketches for the VR world. 

![](/AtTheIsland/Assets/Images/1.JPG "Virtual world sketch")

![](/AtTheIsland/Assets/Images/2.JPG "Virtual world sketch")

![](/AtTheIsland/Assets/Images/3.JPG "Virtual world model")

![](/AtTheIsland/Assets/Images/4.JPG "Virtual world model")

Below is the final virtual world that I have built using pro-builder in Unity3D.

![](/AtTheIsland/Assets/Images/5.JPG "Final virtual world")

### 2. User Interface

The five leaves in the lotus-shaped island represent the five ed-tech companies. Each leaf has a theatre at its end, where a video about the corresponding company is played. While reaching the theatre, the user will be shown information about the company using a screen that moves along with the user. I came up with the following designs for the screen. 

![](/AtTheIsland/Assets/Images/6.JPG "User interface sketch")

![](/AtTheIsland/Assets/Images/7.JPG "User interface")

![](/AtTheIsland/Assets/Images/8.JPG "Final UI")
I have finalized this UI, as both image and text can be shown together.

## User testing
I wanted to get valuable and honest feedback about this application. So, I chose my colleague at workplace whom I thought would be the right user for testing this app. A short intro about him below

*Rup:*
He is a senior QA engineer in the company that I'm working for currently. He is highly creative. He looks for even minutest details while testing. He also plays a lot of video games.

**User Test - 1:** What do you feel about the setting, scale & mood of the scene?

*Rup:* The world is very pleasing and the background music is adding a lot of emotion to the experience. The screen inside the theatre is too close to watch the video. The font color of the text on the moving UI screen is very light.\

    Changed the font color on the moving UI screen. Repositioned the user inside the theatre so that the entire screen is visible. 
    
**User Test - 2:** How is the movement? 

*Rup:* The movement is very comfortable. I felt the move to the island just after the introduction is very fast.

      Reduced the speed for that movement.
      
**User Test - 3:** How is the overall feel of the VR experience?  Any suggestions ?

*Rup:* The overall experience is great. I loved the sunrise, sunset and the stars in the night sky.  I felt that the movement is highly controlled and there is a little freedom for me to navigate wherever I want.

      The control of user's movement is a design decision that I have taken for some good reasons. But I would definitely try giving the user more control on navigation inside the world in the next version of this application. 
      
# Breakdown of final piece

The overall VR experience goes like this.

1. The user will be shown some introduction about the experience and will be taken to the island. 
2. Here the user can select any of the companies and can explore further on their own.
3. The day/night cycle happens periodically throughout the experience.

# Conclusion

It's an amazing experience for me working on this project. I have spent almost one month working on it and learned so many things including Blender, Probuilder and Real-time global illumination. I have done a lot of C# scripting. I'm able to create gameplay interactions very quickly.  I have become better with scale in VR.

# Next Steps..

As real-time global illumination is used in this project, the application runs smoothly only on high-end mobile devices. I would like to optimize this application in terms of processing power it takes while not comprising on the overall quality of the experience. 
