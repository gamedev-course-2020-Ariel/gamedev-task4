# gamedev-task4

# Jump star game

A game where a star has to jump on surfaces and is aim to reach as high as possible without falling.
In this game there are three different levels becoming difficult from stage to stage.


**Created by:**

[Netanel Davidov](https://github.com/netanel208)

[Odelia Hochman](https://github.com/OdeliaHochman)





**Link to itch.io:** 



## Player :

The player has an option to move right,left and jump. 
The moving is done using the arrow keys and doing so activates the animation that matches the movement.

- `space key` - makes the player jump.
- `double space key` - makes the player double jump
- `right key` - moves the player right.
- `left key` - moves the player left.



**Level 1:**

![image](https://user-images.githubusercontent.com/45036697/82336203-f2a11600-99f2-11ea-88d7-72412e32ad03.png)



**Level 2:**

![image](https://user-images.githubusercontent.com/45036697/82336610-7bb84d00-99f3-11ea-9b50-b5e8508dc4e5.png)




**Level 3:**

![image](https://user-images.githubusercontent.com/45036697/82336760-a1dded00-99f3-11ea-80d1-4246124b7907.png)

The differences between each level are the spacings and distances between the platforms, their size and their arrangement in space.

## The code

The following code shows what happens when the player collides at the bottom of the screen, ie collides with the lower border. The player will move to the beginning of the current level he is in.
```C#
        private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject camera = GameObject.Find("Main Camera");
        float y_cam = camera.transform.position.y;
        float y_level1 = GameObject.Find("level1platform").transform.position.y + 0.5f;
        float y_level2 = GameObject.Find("level2platform").transform.position.y + 0.5f;
        float y_level3 = GameObject.Find("level3platform").transform.position.y + 0.5f;
        if (y_cam> y_level3)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, y_level3, camera.transform.position.z);
            collision.gameObject.transform.position = new Vector3(0, y_level3, collision.gameObject.transform.position.z);
        }
        else if (y_cam > y_level2)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, y_level2, camera.transform.position.z);
            collision.gameObject.transform.position = new Vector3(0, y_level2, collision.gameObject.transform.position.z);
        }
        else if (y_cam > y_level1)
        {
            camera.transform.position = new Vector3(camera.transform.position.x, y_level1, camera.transform.position.z);
            collision.gameObject.transform.position = new Vector3(0, y_level1, collision.gameObject.transform.position.z);
        }
    }
```

The following code shows how the camera and its borders should start to rise:
```C#
 if(Math.Abs(trackObject.transform.position.y - level1.transform.position.y) > 2)
        {
            Vector3 height = new Vector3(0, 0.5f * Time.deltaTime, 0);
            this.transform.position += height;
        }
```

The following code shows how to exert forces on the player that will make him move and gain momentum:
```C#
 void Update()
    {
        if (isGrounded)
        {
            float horizontal = Input.GetAxis("Horizontal");
            rb.AddForce(new Vector3(horizontal * forceSize, 0, 0), forceMode);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "platform" || collision.gameObject.tag == "wall")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "platform" && collision.gameObject.tag != "wall")
            isGrounded = false;
    }
```

